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
	public class ExchangeStartOkNpcShopMessage : NetworkMessage
	{
		public const uint Id = 5255;
		public override uint MessageId => Id;
		public double npcSellerId { get; set; }
		public ushort tokenId { get; set; }
		public IEnumerable<ObjectItemToSellInNpcShop> objectsInfos { get; set; }

		public ExchangeStartOkNpcShopMessage(double npcSellerId, ushort tokenId, IEnumerable<ObjectItemToSellInNpcShop> objectsInfos)
		{
			this.npcSellerId = npcSellerId;
			this.tokenId = tokenId;
			this.objectsInfos = objectsInfos;
		}

		public ExchangeStartOkNpcShopMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(npcSellerId);
			writer.WriteVarUShort(tokenId);
			writer.WriteShort((short)objectsInfos.Count());
			foreach (var objectToSend in objectsInfos)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			npcSellerId = reader.ReadDouble();
			tokenId = reader.ReadVarUShort();
			var objectsInfosCount = reader.ReadUShort();
			var objectsInfos_ = new ObjectItemToSellInNpcShop[objectsInfosCount];
			for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
			{
				var objectToAdd = new ObjectItemToSellInNpcShop();
				objectToAdd.Deserialize(reader);
				objectsInfos_[objectsInfosIndex] = objectToAdd;
			}
			objectsInfos = objectsInfos_;
		}

	}
}
