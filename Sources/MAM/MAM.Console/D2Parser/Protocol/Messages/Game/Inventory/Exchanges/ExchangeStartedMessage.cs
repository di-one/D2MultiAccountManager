namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStartedMessage : NetworkMessage
	{
		public const uint Id = 9053;
		public override uint MessageId => Id;
		public sbyte exchangeType { get; set; }

		public ExchangeStartedMessage(sbyte exchangeType)
		{
			this.exchangeType = exchangeType;
		}

		public ExchangeStartedMessage() { }

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
