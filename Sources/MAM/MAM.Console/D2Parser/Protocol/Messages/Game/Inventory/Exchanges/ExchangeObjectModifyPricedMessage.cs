namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeObjectModifyPricedMessage : ExchangeObjectMovePricedMessage
	{
		public new const uint Id = 5577;
		public override uint MessageId => Id;

		public ExchangeObjectModifyPricedMessage(uint objectUID, int quantity, ulong price)
		{
			this.objectUID = objectUID;
			this.quantity = quantity;
			this.price = price;
		}

		public ExchangeObjectModifyPricedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
