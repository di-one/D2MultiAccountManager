namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStartOkNpcTradeMessage : NetworkMessage
	{
		public const uint Id = 3859;
		public override uint MessageId => Id;
		public double npcId { get; set; }

		public ExchangeStartOkNpcTradeMessage(double npcId)
		{
			this.npcId = npcId;
		}

		public ExchangeStartOkNpcTradeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(npcId);
		}

		public override void Deserialize(IDataReader reader)
		{
			npcId = reader.ReadDouble();
		}

	}
}
