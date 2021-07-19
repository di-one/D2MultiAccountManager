using AmaknaProxy.API.Managers;
using AmaknaProxy.API.Protocol;
using MAM.Console.Core.Controllers;
using MAM.Console.Sniffer;
using MAM.Console.WindowsControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAM.Console
{
    class Program
    {
        public static List<GameController> Players = new List<GameController>();

        private static int _interfaceIndex;
        static void Main(string[] args)
        {
            ConsoleManager.InitLogger(new AmaknaProxy.API.Utils.Logger.ContainerLogger());
            ProtocolTypeManager.Initialize();
            MessageReceiver.Initialize();
            ControlManager controlButton1 = new ControlManager();
            ControlManager controlButton2 = new ControlManager();
            GroupController groupController = new GroupController();

            controlButton1.OnKeyDown += OnKeyDown;
            controlButton1.Start(Key.MOUSE_BUTTON_4);

            controlButton2.OnKeyDown += OnKeyDown;
            controlButton2.Start(Key.MOUSE_BUTTON_5);

            // Chose network interface
            _interfaceIndex = ChoseNetworInterface();

            if (_interfaceIndex == -1)
            {
                System.Console.WriteLine("Error : cant find interface !");
            }
            else
            {
                // Select needed dofus windows
                //ChoseDofusWindows();

                // When finish, start listening for all windows
                StartListen();
            }

            System.Console.ReadLine();
        }

        private static int ChoseNetworInterface()
        {
            System.Console.WriteLine(SocketListener.GetListDevicesMessage());
            string str = System.Console.ReadLine();

            int res = 0;
            if (int.TryParse(str, out res))
            {
                return res;
            }

            return -1;
        }

        private static void StartListen()
        {
            System.Console.WriteLine("Start Listening ...");

            var processes = Applications.GetD2RunningProcesses;

            System.Console.WriteLine("Processes founded : " + processes.Length);

            for (int i = 0; i < processes.Length; i++)
            {
                List<string> ips = NetStat.GetTCPServerIPs(processes[i]);
                string ip = "";

                for (int j = 0; j < ips.Count; j++)
                {
                    string split0 = ips[j].Split(':')[0];
                    string first = split0.Split('.')[0];
                    if (first == "172" || first == "34" || first == "52" || first == "54")
                    {
                        ip = ips[j];
                        break;
                    }
                }

                GameController gc = new GameController();
                SocketListener sl = SocketListener.ListenIp(ip, _interfaceIndex);
                GroupController.Instance.GameControllers.Add(gc);

                Players.Add(gc);

                gc.Start(sl, processes[i]);
            }
        }

        public static void OnKeyDown(Key key)
        {
            Task.Factory.StartNew(async () =>
            {
                // Next window
                GroupController.Instance.Next();

                // If is fighting, we dont want show window of deads players
                //if (GameController.Owner.IsFighting)
                //{
                //    int count = 0;
                //    while (GameController.Owner.FightController.AvailablePlayers.Contains(GroupController.Instance.ActualController) == false)
                //    {
                //        GroupController.Instance.Next();
                //        count++;

                //        if (count > GroupController.Instance.GameControllers.Count)
                //        {
                //            System.Console.WriteLine("[Next Window] - Error : All players is dead ??");
                //            break;
                //        }
                //    }
                //}

                Applications.FocusProcess(GroupController.Instance.ActualController.Process);

                // Next Window + Click
                if (key == Key.MOUSE_BUTTON_5)
                {
                    // Delay is high for potential lags
                    // Todo : Check if MoveDeplacement packet is received, or reclick
                    Random random = new Random();
                    await Task.Delay(random.Next(200, 250));

                    // click
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);

                    random = new Random();
                    await Task.Delay(random.Next(25, 35));

                    //// up
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                }
            });
        }

        //private static void ChoseDofusWindows()
        //{
        //    var processes = Applications.GetD2RunningProcesses;

        //    // -- For each windows : chose needed ip
        //    for (int i = 0; i < processes.Length; i++)
        //    {

        //    }
        //}
    }
}
