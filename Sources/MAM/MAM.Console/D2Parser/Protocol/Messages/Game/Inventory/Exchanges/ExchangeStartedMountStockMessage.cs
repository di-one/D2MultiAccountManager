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
	public class ExchangeStartedMountStockMessage : NetworkMessage
	{
		public const uint Id = 9501;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItem> objectsInfos { get; set; }

		public ExchangeStartedMountStockMessage(IEnumerable<ObjectItem> objectsInfos)
		{
			this.objectsInfos = objectsInfos;
		}

		public ExchangeStartedMountStockMessage() { }

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
			var objectsInfos_ = new ObjectItem[objectsInfosCount];
			for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
			{
				var objectToAdd = new ObjectItem();
				objectToAdd.Deserialize(reader);
				objectsInfos_[objectsInfosIndex] = objectToAdd;
			}
			objectsInfos = objectsInfos_;
		}

	}
}
