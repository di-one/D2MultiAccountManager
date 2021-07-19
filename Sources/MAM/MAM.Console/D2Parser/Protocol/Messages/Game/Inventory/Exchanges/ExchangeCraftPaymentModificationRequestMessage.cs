namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeCraftPaymentModificationRequestMessage : NetworkMessage
	{
		public const uint Id = 4308;
		public override uint MessageId => Id;
		public ulong quantity { get; set; }

		public ExchangeCraftPaymentModificationRequestMessage(ulong quantity)
		{
			this.quantity = quantity;
		}

		public ExchangeCraftPaymentModificationRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			quantity = reader.ReadVarULong();
		}

	}
}
