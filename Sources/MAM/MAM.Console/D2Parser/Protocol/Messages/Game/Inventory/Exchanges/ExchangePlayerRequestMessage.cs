namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangePlayerRequestMessage : ExchangeRequestMessage
	{
		public new const uint Id = 7247;
		public override uint MessageId => Id;
		public ulong target { get; set; }

		public ExchangePlayerRequestMessage(sbyte exchangeType, ulong target)
		{
			this.exchangeType = exchangeType;
			this.target = target;
		}

		public ExchangePlayerRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(target);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			target = reader.ReadVarULong();
		}

	}
}
