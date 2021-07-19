namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHouseItemRemoveOkMessage : NetworkMessage
	{
		public const uint Id = 3302;
		public override uint MessageId => Id;
		public int sellerId { get; set; }

		public ExchangeBidHouseItemRemoveOkMessage(int sellerId)
		{
			this.sellerId = sellerId;
		}

		public ExchangeBidHouseItemRemoveOkMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(sellerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			sellerId = reader.ReadInt();
		}

	}
}
