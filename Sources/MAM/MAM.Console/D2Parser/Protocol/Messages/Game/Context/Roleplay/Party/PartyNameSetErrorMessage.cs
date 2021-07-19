namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyNameSetErrorMessage : AbstractPartyMessage
	{
		public new const uint Id = 8663;
		public override uint MessageId => Id;
		public sbyte result { get; set; }

		public PartyNameSetErrorMessage(uint partyId, sbyte result)
		{
			this.partyId = partyId;
			this.result = result;
		}

		public PartyNameSetErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(result);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			result = reader.ReadSByte();
		}

	}
}
