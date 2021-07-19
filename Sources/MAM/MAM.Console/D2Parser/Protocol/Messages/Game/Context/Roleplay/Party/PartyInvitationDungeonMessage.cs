namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyInvitationDungeonMessage : PartyInvitationMessage
	{
		public new const uint Id = 5459;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }

		public PartyInvitationDungeonMessage(uint partyId, sbyte partyType, string partyName, sbyte maxParticipants, ulong fromId, string fromName, ulong toId, ushort dungeonId)
		{
			this.partyId = partyId;
			this.partyType = partyType;
			this.partyName = partyName;
			this.maxParticipants = maxParticipants;
			this.fromId = fromId;
			this.fromName = fromName;
			this.toId = toId;
			this.dungeonId = dungeonId;
		}

		public PartyInvitationDungeonMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(dungeonId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			dungeonId = reader.ReadVarUShort();
		}

	}
}
