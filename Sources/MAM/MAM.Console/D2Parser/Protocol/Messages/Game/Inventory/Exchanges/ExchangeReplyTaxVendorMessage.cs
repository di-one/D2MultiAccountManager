namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeReplyTaxVendorMessage : NetworkMessage
	{
		public const uint Id = 8775;
		public override uint MessageId => Id;
		public ulong objectValue { get; set; }
		public ulong totalTaxValue { get; set; }

		public ExchangeReplyTaxVendorMessage(ulong objectValue, ulong totalTaxValue)
		{
			this.objectValue = objectValue;
			this.totalTaxValue = totalTaxValue;
		}

		public ExchangeReplyTaxVendorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(objectValue);
			writer.WriteVarULong(totalTaxValue);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectValue = reader.ReadVarULong();
			totalTaxValue = reader.ReadVarULong();
		}

	}
}
