namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockSellBuyDialogMessage : NetworkMessage
	{
		public const uint Id = 4481;
		public override uint MessageId => Id;
		public bool bsell { get; set; }
		public uint ownerId { get; set; }
		public ulong price { get; set; }

		public PaddockSellBuyDialogMessage(bool bsell, uint ownerId, ulong price)
		{
			this.bsell = bsell;
			this.ownerId = ownerId;
			this.price = price;
		}

		public PaddockSellBuyDialogMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(bsell);
			writer.WriteVarUInt(ownerId);
			writer.WriteVarULong(price);
		}

		public override void Deserialize(IDataReader reader)
		{
			bsell = reader.ReadBoolean();
			ownerId = reader.ReadVarUInt();
			price = reader.ReadVarULong();
		}

	}
}
