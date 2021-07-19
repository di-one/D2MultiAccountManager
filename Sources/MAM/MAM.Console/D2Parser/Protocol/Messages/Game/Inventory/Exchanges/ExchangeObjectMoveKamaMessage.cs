namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeObjectMoveKamaMessage : NetworkMessage
	{
		public const uint Id = 4490;
		public override uint MessageId => Id;
		public long quantity { get; set; }

		public ExchangeObjectMoveKamaMessage(long quantity)
		{
			this.quantity = quantity;
		}

		public ExchangeObjectMoveKamaMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarLong(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			quantity = reader.ReadVarLong();
		}

	}
}
