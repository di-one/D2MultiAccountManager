namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeKamaModifiedMessage : ExchangeObjectMessage
	{
		public new const uint Id = 8636;
		public override uint MessageId => Id;
		public ulong quantity { get; set; }

		public ExchangeKamaModifiedMessage(bool remote, ulong quantity)
		{
			this.remote = remote;
			this.quantity = quantity;
		}

		public ExchangeKamaModifiedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			quantity = reader.ReadVarULong();
		}

	}
}
