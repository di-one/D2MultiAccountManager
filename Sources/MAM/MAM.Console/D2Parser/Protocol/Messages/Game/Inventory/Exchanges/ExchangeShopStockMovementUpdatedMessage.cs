namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeShopStockMovementUpdatedMessage : NetworkMessage
	{
		public const uint Id = 8247;
		public override uint MessageId => Id;
		public ObjectItemToSell objectInfo { get; set; }

		public ExchangeShopStockMovementUpdatedMessage(ObjectItemToSell objectInfo)
		{
			this.objectInfo = objectInfo;
		}

		public ExchangeShopStockMovementUpdatedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			objectInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectInfo = new ObjectItemToSell();
			objectInfo.Deserialize(reader);
		}

	}
}
