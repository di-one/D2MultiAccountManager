namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyInvitationDungeonDetailsMessage : PartyInvitationDetailsMessage
	{
		public new const uint Id = 984;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }
		public IEnumerable<bool> playersDungeonReady { get; set; }

		public PartyInvitationDungeonDetailsMessage(uint partyId, sbyte partyType, string partyName, ulong fromId, string fromName, ulong leaderId, IEnumerable<PartyInvitationMemberInformations> members, IEnumerable<PartyGuestInformations> guests, ushort dungeonId, IEnumerable<bool> playersDungeonReady)
		{
			this.partyId = partyId;
			this.partyType = partyType;
			this.partyName = partyName;
			this.fromId = fromId;
			this.fromName = fromName;
			this.leaderId = leaderId;
			this.members = members;
			this.guests = guests;
			this.dungeonId = dungeonId;
			this.playersDungeonReady = playersDungeonReady;
		}

		public PartyInvitationDungeonDetailsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(dungeonId);
			writer.WriteShort((short)playersDungeonReady.Count());
			foreach (var objectToSend in playersDungeonReady)
            {
				writer.WriteBoolean(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			dungeonId = reader.ReadVarUShort();
			var playersDungeonReadyCount = reader.ReadUShort();
			var playersDungeonReady_ = new bool[playersDungeonReadyCount];
			for (var playersDungeonReadyIndex = 0; playersDungeonReadyIndex < playersDungeonReadyCount; playersDungeonReadyIndex++)
			{
				playersDungeonReady_[playersDungeonReadyIndex] = reader.ReadBoolean();
			}
			playersDungeonReady = playersDungeonReady_;
		}

	}
}
