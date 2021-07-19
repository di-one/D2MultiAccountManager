namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockSellRequestMessage : NetworkMessage
	{
		public const uint Id = 5147;
		public override uint MessageId => Id;
		public ulong price { get; set; }
		public bool forSale { get; set; }

		public PaddockSellRequestMessage(ulong price, bool forSale)
		{
			this.price = price;
			this.forSale = forSale;
		}

		public PaddockSellRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(price);
			writer.WriteBoolean(forSale);
		}

		public override void Deserialize(IDataReader reader)
		{
			price = reader.ReadVarULong();
			forSale = reader.ReadBoolean();
		}

	}
}
