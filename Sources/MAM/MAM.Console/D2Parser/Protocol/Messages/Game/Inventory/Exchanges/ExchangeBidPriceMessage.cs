namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidPriceMessage : NetworkMessage
	{
		public const uint Id = 4482;
		public override uint MessageId => Id;
		public ushort genericId { get; set; }
		public long averagePrice { get; set; }

		public ExchangeBidPriceMessage(ushort genericId, long averagePrice)
		{
			this.genericId = genericId;
			this.averagePrice = averagePrice;
		}

		public ExchangeBidPriceMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(genericId);
			writer.WriteVarLong(averagePrice);
		}

		public override void Deserialize(IDataReader reader)
		{
			genericId = reader.ReadVarUShort();
			averagePrice = reader.ReadVarLong();
		}

	}
}
