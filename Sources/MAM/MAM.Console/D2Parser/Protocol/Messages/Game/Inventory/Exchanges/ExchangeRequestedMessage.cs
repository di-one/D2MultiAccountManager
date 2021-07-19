namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeRequestedMessage : NetworkMessage
	{
		public const uint Id = 6957;
		public override uint MessageId => Id;
		public sbyte exchangeType { get; set; }

		public ExchangeRequestedMessage(sbyte exchangeType)
		{
			this.exchangeType = exchangeType;
		}

		public ExchangeRequestedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(exchangeType);
		}

		public override void Deserialize(IDataReader reader)
		{
			exchangeType = reader.ReadSByte();
		}

	}
}
