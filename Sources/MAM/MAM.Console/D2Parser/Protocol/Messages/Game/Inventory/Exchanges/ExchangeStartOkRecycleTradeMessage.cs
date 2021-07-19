namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStartOkRecycleTradeMessage : NetworkMessage
	{
		public const uint Id = 1272;
		public override uint MessageId => Id;
		public short percentToPrism { get; set; }
		public short percentToPlayer { get; set; }

		public ExchangeStartOkRecycleTradeMessage(short percentToPrism, short percentToPlayer)
		{
			this.percentToPrism = percentToPrism;
			this.percentToPlayer = percentToPlayer;
		}

		public ExchangeStartOkRecycleTradeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(percentToPrism);
			writer.WriteShort(percentToPlayer);
		}

		public override void Deserialize(IDataReader reader)
		{
			percentToPrism = reader.ReadShort();
			percentToPlayer = reader.ReadShort();
		}

	}
}
