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
	public class ExchangeShopStockMultiMovementUpdatedMessage : NetworkMessage
	{
		public const uint Id = 5634;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItemToSell> objectInfoList { get; set; }

		public ExchangeShopStockMultiMovementUpdatedMessage(IEnumerable<ObjectItemToSell> objectInfoList)
		{
			this.objectInfoList = objectInfoList;
		}

		public ExchangeShopStockMultiMovementUpdatedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)objectInfoList.Count());
			foreach (var objectToSend in objectInfoList)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var objectInfoListCount = reader.ReadUShort();
			var objectInfoList_ = new ObjectItemToSell[objectInfoListCount];
			for (var objectInfoListIndex = 0; objectInfoListIndex < objectInfoListCount; objectInfoListIndex++)
			{
				var objectToAdd = new ObjectItemToSell();
				objectToAdd.Deserialize(reader);
				objectInfoList_[objectInfoListIndex] = objectToAdd;
			}
			objectInfoList = objectInfoList_;
		}

	}
}
