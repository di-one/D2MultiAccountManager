namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeRequestedTradeMessage : ExchangeRequestedMessage
	{
		public new const uint Id = 8838;
		public override uint MessageId => Id;
		public ulong source { get; set; }
		public ulong target { get; set; }

		public ExchangeRequestedTradeMessage(sbyte exchangeType, ulong source, ulong target)
		{
			this.exchangeType = exchangeType;
			this.source = source;
			this.target = target;
		}

		public ExchangeRequestedTradeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(source);
			writer.WriteVarULong(target);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			source = reader.ReadVarULong();
			target = reader.ReadVarULong();
		}

	}
}
