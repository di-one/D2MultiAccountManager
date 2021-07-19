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
	public class ExchangeStartedBidSellerMessage : NetworkMessage
	{
		public const uint Id = 4057;
		public override uint MessageId => Id;
		public SellerBuyerDescriptor sellerDescriptor { get; set; }
		public IEnumerable<ObjectItemToSellInBid> objectsInfos { get; set; }

		public ExchangeStartedBidSellerMessage(SellerBuyerDescriptor sellerDescriptor, IEnumerable<ObjectItemToSellInBid> objectsInfos)
		{
			this.sellerDescriptor = sellerDescriptor;
			this.objectsInfos = objectsInfos;
		}

		public ExchangeStartedBidSellerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			sellerDescriptor.Serialize(writer);
			writer.WriteShort((short)objectsInfos.Count());
			foreach (var objectToSend in objectsInfos)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			sellerDescriptor = new SellerBuyerDescriptor();
			sellerDescriptor.Deserialize(reader);
			var objectsInfosCount = reader.ReadUShort();
			var objectsInfos_ = new ObjectItemToSellInBid[objectsInfosCount];
			for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
			{
				var objectToAdd = new ObjectItemToSellInBid();
				objectToAdd.Deserialize(reader);
				objectsInfos_[objectsInfosIndex] = objectToAdd;
			}
			objectsInfos = objectsInfos_;
		}

	}
}
