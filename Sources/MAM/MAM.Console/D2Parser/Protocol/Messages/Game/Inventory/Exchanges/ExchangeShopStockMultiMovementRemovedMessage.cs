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
	public class ExchangeShopStockMultiMovementRemovedMessage : NetworkMessage
	{
		public const uint Id = 6186;
		public override uint MessageId => Id;
		public IEnumerable<uint> objectIdList { get; set; }

		public ExchangeShopStockMultiMovementRemovedMessage(IEnumerable<uint> objectIdList)
		{
			this.objectIdList = objectIdList;
		}

		public ExchangeShopStockMultiMovementRemovedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)objectIdList.Count());
			foreach (var objectToSend in objectIdList)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var objectIdListCount = reader.ReadUShort();
			var objectIdList_ = new uint[objectIdListCount];
			for (var objectIdListIndex = 0; objectIdListIndex < objectIdListCount; objectIdListIndex++)
			{
				objectIdList_[objectIdListIndex] = reader.ReadVarUInt();
			}
			objectIdList = objectIdList_;
		}

	}
}
