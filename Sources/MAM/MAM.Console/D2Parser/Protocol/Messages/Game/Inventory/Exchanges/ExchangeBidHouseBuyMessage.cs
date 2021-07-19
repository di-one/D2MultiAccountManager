namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHouseBuyMessage : NetworkMessage
	{
		public const uint Id = 4755;
		public override uint MessageId => Id;
		public uint uid { get; set; }
		public uint qty { get; set; }
		public ulong price { get; set; }

		public ExchangeBidHouseBuyMessage(uint uid, uint qty, ulong price)
		{
			this.uid = uid;
			this.qty = qty;
			this.price = price;
		}

		public ExchangeBidHouseBuyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(uid);
			writer.WriteVarUInt(qty);
			writer.WriteVarULong(price);
		}

		public override void Deserialize(IDataReader reader)
		{
			uid = reader.ReadVarUInt();
			qty = reader.ReadVarUInt();
			price = reader.ReadVarULong();
		}

	}
}
