namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseBuyResultMessage : NetworkMessage
	{
		public const uint Id = 7480;
		public override uint MessageId => Id;
		public bool secondHand { get; set; }
		public bool bought { get; set; }
		public uint houseId { get; set; }
		public int instanceId { get; set; }
		public ulong realPrice { get; set; }

		public HouseBuyResultMessage(bool secondHand, bool bought, uint houseId, int instanceId, ulong realPrice)
		{
			this.secondHand = secondHand;
			this.bought = bought;
			this.houseId = houseId;
			this.instanceId = instanceId;
			this.realPrice = realPrice;
		}

		public HouseBuyResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, secondHand);
			flag = BooleanByteWrapper.SetFlag(flag, 1, bought);
			writer.WriteByte(flag);
			writer.WriteVarUInt(houseId);
			writer.WriteInt(instanceId);
			writer.WriteVarULong(realPrice);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			secondHand = BooleanByteWrapper.GetFlag(flag, 0);
			bought = BooleanByteWrapper.GetFlag(flag, 1);
			houseId = reader.ReadVarUInt();
			instanceId = reader.ReadInt();
			realPrice = reader.ReadVarULong();
		}

	}
}
