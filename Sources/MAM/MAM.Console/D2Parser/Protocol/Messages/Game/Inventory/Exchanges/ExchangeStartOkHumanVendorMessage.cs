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
	public class ExchangeStartOkHumanVendorMessage : NetworkMessage
	{
		public const uint Id = 665;
		public override uint MessageId => Id;
		public double sellerId { get; set; }
		public IEnumerable<ObjectItemToSellInHumanVendorShop> objectsInfos { get; set; }

		public ExchangeStartOkHumanVendorMessage(double sellerId, IEnumerable<ObjectItemToSellInHumanVendorShop> objectsInfos)
		{
			this.sellerId = sellerId;
			this.objectsInfos = objectsInfos;
		}

		public ExchangeStartOkHumanVendorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(sellerId);
			writer.WriteShort((short)objectsInfos.Count());
			foreach (var objectToSend in objectsInfos)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			sellerId = reader.ReadDouble();
			var objectsInfosCount = reader.ReadUShort();
			var objectsInfos_ = new ObjectItemToSellInHumanVendorShop[objectsInfosCount];
			for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
			{
				var objectToAdd = new ObjectItemToSellInHumanVendorShop();
				objectToAdd.Deserialize(reader);
				objectsInfos_[objectsInfosIndex] = objectToAdd;
			}
			objectsInfos = objectsInfos_;
		}

	}
}
