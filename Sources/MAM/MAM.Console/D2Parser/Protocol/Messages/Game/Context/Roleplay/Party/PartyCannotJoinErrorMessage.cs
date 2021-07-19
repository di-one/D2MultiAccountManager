namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyCannotJoinErrorMessage : AbstractPartyMessage
	{
		public new const uint Id = 1626;
		public override uint MessageId => Id;
		public sbyte reason { get; set; }

		public PartyCannotJoinErrorMessage(uint partyId, sbyte reason)
		{
			this.partyId = partyId;
			this.reason = reason;
		}

		public PartyCannotJoinErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(reason);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			reason = reader.ReadSByte();
		}

	}
}
