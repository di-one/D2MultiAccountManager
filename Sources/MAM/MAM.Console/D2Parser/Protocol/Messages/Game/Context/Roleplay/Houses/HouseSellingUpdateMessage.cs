namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseSellingUpdateMessage : NetworkMessage
	{
		public const uint Id = 3165;
		public override uint MessageId => Id;
		public uint houseId { get; set; }
		public int instanceId { get; set; }
		public bool secondHand { get; set; }
		public ulong realPrice { get; set; }
		public AccountTagInformation buyerTag { get; set; }

		public HouseSellingUpdateMessage(uint houseId, int instanceId, bool secondHand, ulong realPrice, AccountTagInformation buyerTag)
		{
			this.houseId = houseId;
			this.instanceId = instanceId;
			this.secondHand = secondHand;
			this.realPrice = realPrice;
			this.buyerTag = buyerTag;
		}

		public HouseSellingUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(houseId);
			writer.WriteInt(instanceId);
			writer.WriteBoolean(secondHand);
			writer.WriteVarULong(realPrice);
			buyerTag.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			houseId = reader.ReadVarUInt();
			instanceId = reader.ReadInt();
			secondHand = reader.ReadBoolean();
			realPrice = reader.ReadVarULong();
			buyerTag = new AccountTagInformation();
			buyerTag.Deserialize(reader);
		}

	}
}
