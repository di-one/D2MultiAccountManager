namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeRequestMessage : NetworkMessage
	{
		public const uint Id = 8781;
		public override uint MessageId => Id;
		public sbyte exchangeType { get; set; }

		public ExchangeRequestMessage(sbyte exchangeType)
		{
			this.exchangeType = exchangeType;
		}

		public ExchangeRequestMessage() { }

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
