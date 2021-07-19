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
	public class ExchangeShopStockStartedMessage : NetworkMessage
	{
		public const uint Id = 350;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItemToSell> objectsInfos { get; set; }

		public ExchangeShopStockStartedMessage(IEnumerable<ObjectItemToSell> objectsInfos)
		{
			this.objectsInfos = objectsInfos;
		}

		public ExchangeShopStockStartedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)objectsInfos.Count());
			foreach (var objectToSend in objectsInfos)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var objectsInfosCount = reader.ReadUShort();
			var objectsInfos_ = new ObjectItemToSell[objectsInfosCount];
			for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
			{
				var objectToAdd = new ObjectItemToSell();
				objectToAdd.Deserialize(reader);
				objectsInfos_[objectsInfosIndex] = objectToAdd;
			}
			objectsInfos = objectsInfos_;
		}

	}
}
