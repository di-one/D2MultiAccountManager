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
	public class ExchangeBidPriceForSellerMessage : ExchangeBidPriceMessage
	{
		public new const uint Id = 7264;
		public override uint MessageId => Id;
		public bool allIdentical { get; set; }
		public IEnumerable<ulong> minimalPrices { get; set; }

		public ExchangeBidPriceForSellerMessage(ushort genericId, long averagePrice, bool allIdentical, IEnumerable<ulong> minimalPrices)
		{
			this.genericId = genericId;
			this.averagePrice = averagePrice;
			this.allIdentical = allIdentical;
			this.minimalPrices = minimalPrices;
		}

		public ExchangeBidPriceForSellerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(allIdentical);
			writer.WriteShort((short)minimalPrices.Count());
			foreach (var objectToSend in minimalPrices)
            {
				writer.WriteVarULong(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			allIdentical = reader.ReadBoolean();
			var minimalPricesCount = reader.ReadUShort();
			var minimalPrices_ = new ulong[minimalPricesCount];
			for (var minimalPricesIndex = 0; minimalPricesIndex < minimalPricesCount; minimalPricesIndex++)
			{
				minimalPrices_[minimalPricesIndex] = reader.ReadVarULong();
			}
			minimalPrices = minimalPrices_;
		}

	}
}
