using AmaknaProxy.API.Network;
using AmaknaProxy.API.Protocol.Messages;
using MAM.Console.D2Parser;
using MAM.Console.Sniffer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAM.Console.Core.Controllers
{
    public class GameController
    {
        public string Name { get; private set; }
        public ulong ID { get; private set; }
        public int Initiative { get; private set; }

        public FightController FightController => _fight;

        public static GameController Owner;

        public bool IsFighting => _fight != null;

        public Process Process { get; private set; }

        private PacketAnalyzer _packetAnalyzer;
        private SocketListener _socketListener;

        private bool _started;
        private bool _isOwner;

        private FightController _fight;

        public void Start(SocketListener listener, Process process)
        {
            if (_started == false)
            {
                System.Console.WriteLine("Account Ready !");

                Process = process;

                _packetAnalyzer = new PacketAnalyzer();
                _socketListener = listener;

                _socketListener.GetPacketAction += _packetAnalyzer.OnGetPacket;
                _packetAnalyzer.ReceiveMessageAction += OnGetMessage;

                _started = true;
            }
            else
            {
                System.Console.WriteLine("Error : Game controller already started !");
            }
        }

        private void OnGetMessage(NetworkMessage message)
        {
            //System.Console.WriteLine("Message Reveive : " + message.GetType());

            if (message.GetType() == typeof(CharacterSelectedSuccessMessage))
            {
                OnSelectCharacter((CharacterSelectedSuccessMessage)message);
            }

            else if (message.GetType() == typeof(PartyJoinMessage))
            {
                OnPartyJoin((PartyJoinMessage)message);
            }

            // Only if owner
            else if (message.GetType() == typeof(PartyUpdateMessage))
            {
                OnPartyUpdate((PartyUpdateMessage)message);
            }

            // Only if owner
            else if (message.GetType() == typeof(PartyNewMemberMessage))
            {
                OnPartyNewMember((PartyNewMemberMessage)message);
            }

            else if (message.GetType() == typeof(GameFightStartMessage))
            {
                OnGameFightStart((GameFightStartMessage)message);
            }

            else if (message.GetType() == typeof(GameFightTurnListMessage))
            {
                OnGameFightTurnList((GameFightTurnListMessage)message);
            }

            else if (message.GetType() == typeof(GameFightTurnFinishMessage))
            {
                OnGameFightTurnFinish((GameFightTurnFinishMessage)message);
            }

            else if (message.GetType() == typeof(GameFightEndMessage))
            {
                OnGameFightEnd((GameFightEndMessage)message);
            }
        }

        private void OnGameFightStart(GameFightStartMessage message)
        {
            if (_isOwner)
            {
                System.Console.WriteLine("Fight start");
                _fight = new FightController(Program.Players);
            }
        }

        private void OnGameFightTurnList(GameFightTurnListMessage message)
        {
            if (_isOwner)
            {
                System.Console.WriteLine("Fight turn list");
                _fight.Refresh(message.ids, message.deadsIds);
            }
        }

        private void OnGameFightTurnFinish(GameFightTurnFinishMessage message)
        {
            if (_isOwner)
            {
                System.Console.WriteLine("Fight turn finish");
                //Program.OnKeyDown(WindowsControls.Key.MOUSE_BUTTON_4);
            }
        }

        private void OnGameFightEnd(GameFightEndMessage message)
        {
            if (_isOwner)
            {
                System.Console.WriteLine("End fight");
                _fight = null;
            }
        }

        private void OnSelectCharacter(CharacterSelectedSuccessMessage message)
        {
            Name = message.infos.name;
            ID = message.infos.objectId;

            System.Console.WriteLine($"Character selected : {message.infos.name} ({ID})");
        }

        private void OnPartyJoin(PartyJoinMessage message)
        {
            _isOwner = message.members.Count() == 1;
            var member = message.members.FirstOrDefault(x => x.name == Name);


            System.Console.WriteLine($"[{Name}] Party join | isowner : {_isOwner}");

            if (member != null)
            {
                Initiative = member.initiative;
                System.Console.WriteLine($"[{Name}] Update initiative");
            }
            else
            {
                System.Console.WriteLine($"[{Name}] Player not found");
            }

            if (_isOwner)
            {
                GroupController.Instance.Leader = this;
                Owner = this;
            }
        }

        private void OnPartyUpdate(PartyUpdateMessage message)
        {
            // Not update during fight
            if (Owner.IsFighting == false)
            {
                System.Console.WriteLine($"[{Name}] Party Update");

                // Is mine
                if (message.memberInformations.name == Name)
                {
                    System.Console.WriteLine($"[{Name}] Update initiative");
                    Initiative = message.memberInformations.initiative;
                }

                if (_isOwner)
                {
                    // recalculate groupe order
                    GroupController.Instance.ReOrder();
                }
            }
        }

        private void OnPartyNewMember(PartyNewMemberMessage message)
        {

            System.Console.WriteLine($"[{Name}] Party New Member ({message.memberInformations.name})");

            if (_isOwner)
            {
                // Recalculate groupe order
                GroupController.Instance.ReOrder();
            }
        }

        //private void OnCharacterStatsList(CharacterStatsListMessage message)
        //{
        //    Initiative = message.stats.characteristics
        //}
    }
}
