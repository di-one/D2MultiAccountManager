namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHouseItemAddOkMessage : NetworkMessage
	{
		public const uint Id = 8921;
		public override uint MessageId => Id;
		public ObjectItemToSellInBid itemInfo { get; set; }

		public ExchangeBidHouseItemAddOkMessage(ObjectItemToSellInBid itemInfo)
		{
			this.itemInfo = itemInfo;
		}

		public ExchangeBidHouseItemAddOkMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			itemInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			itemInfo = new ObjectItemToSellInBid();
			itemInfo.Deserialize(reader);
		}

	}
}
