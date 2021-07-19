namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeItemAutoCraftStopedMessage : NetworkMessage
	{
		public const uint Id = 571;
		public override uint MessageId => Id;
		public sbyte reason { get; set; }

		public ExchangeItemAutoCraftStopedMessage(sbyte reason)
		{
			this.reason = reason;
		}

		public ExchangeItemAutoCraftStopedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(reason);
		}

		public override void Deserialize(IDataReader reader)
		{
			reason = reader.ReadSByte();
		}

	}
}
