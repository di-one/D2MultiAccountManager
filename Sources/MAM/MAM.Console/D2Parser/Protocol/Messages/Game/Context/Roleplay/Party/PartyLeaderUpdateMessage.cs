namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyLeaderUpdateMessage : AbstractPartyEventMessage
	{
		public new const uint Id = 8574;
		public override uint MessageId => Id;
		public ulong partyLeaderId { get; set; }

		public PartyLeaderUpdateMessage(uint partyId, ulong partyLeaderId)
		{
			this.partyId = partyId;
			this.partyLeaderId = partyLeaderId;
		}

		public PartyLeaderUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(partyLeaderId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			partyLeaderId = reader.ReadVarULong();
		}

	}
}
