namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeObjectMovePricedMessage : ExchangeObjectMoveMessage
	{
		public new const uint Id = 4356;
		public override uint MessageId => Id;
		public ulong price { get; set; }

		public ExchangeObjectMovePricedMessage(uint objectUID, int quantity, ulong price)
		{
			this.objectUID = objectUID;
			this.quantity = quantity;
			this.price = price;
		}

		public ExchangeObjectMovePricedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(price);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			price = reader.ReadVarULong();
		}

	}
}
