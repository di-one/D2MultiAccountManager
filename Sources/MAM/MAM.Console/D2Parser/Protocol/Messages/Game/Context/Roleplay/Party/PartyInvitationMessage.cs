namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyInvitationMessage : AbstractPartyMessage
	{
		public new const uint Id = 110;
		public override uint MessageId => Id;
		public sbyte partyType { get; set; }
		public string partyName { get; set; }
		public sbyte maxParticipants { get; set; }
		public ulong fromId { get; set; }
		public string fromName { get; set; }
		public ulong toId { get; set; }

		public PartyInvitationMessage(uint partyId, sbyte partyType, string partyName, sbyte maxParticipants, ulong fromId, string fromName, ulong toId)
		{
			this.partyId = partyId;
			this.partyType = partyType;
			this.partyName = partyName;
			this.maxParticipants = maxParticipants;
			this.fromId = fromId;
			this.fromName = fromName;
			this.toId = toId;
		}

		public PartyInvitationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(partyType);
			writer.WriteUTF(partyName);
			writer.WriteSByte(maxParticipants);
			writer.WriteVarULong(fromId);
			writer.WriteUTF(fromName);
			writer.WriteVarULong(toId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			partyType = reader.ReadSByte();
			partyName = reader.ReadUTF();
			maxParticipants = reader.ReadSByte();
			fromId = reader.ReadVarULong();
			fromName = reader.ReadUTF();
			toId = reader.ReadVarULong();
		}

	}
}
