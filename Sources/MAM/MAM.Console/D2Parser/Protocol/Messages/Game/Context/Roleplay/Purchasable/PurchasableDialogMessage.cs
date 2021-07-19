namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PurchasableDialogMessage : NetworkMessage
	{
		public const uint Id = 7335;
		public override uint MessageId => Id;
		public bool buyOrSell { get; set; }
		public bool secondHand { get; set; }
		public double purchasableId { get; set; }
		public int purchasableInstanceId { get; set; }
		public ulong price { get; set; }

		public PurchasableDialogMessage(bool buyOrSell, bool secondHand, double purchasableId, int purchasableInstanceId, ulong price)
		{
			this.buyOrSell = buyOrSell;
			this.secondHand = secondHand;
			this.purchasableId = purchasableId;
			this.purchasableInstanceId = purchasableInstanceId;
			this.price = price;
		}

		public PurchasableDialogMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, buyOrSell);
			flag = BooleanByteWrapper.SetFlag(flag, 1, secondHand);
			writer.WriteByte(flag);
			writer.WriteDouble(purchasableId);
			writer.WriteInt(purchasableInstanceId);
			writer.WriteVarULong(price);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			buyOrSell = BooleanByteWrapper.GetFlag(flag, 0);
			secondHand = BooleanByteWrapper.GetFlag(flag, 1);
			purchasableId = reader.ReadDouble();
			purchasableInstanceId = reader.ReadInt();
			price = reader.ReadVarULong();
		}

	}
}
