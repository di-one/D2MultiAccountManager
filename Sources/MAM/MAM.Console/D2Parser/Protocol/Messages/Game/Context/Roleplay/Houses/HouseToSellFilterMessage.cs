namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseToSellFilterMessage : NetworkMessage
	{
		public const uint Id = 3948;
		public override uint MessageId => Id;
		public int areaId { get; set; }
		public sbyte atLeastNbRoom { get; set; }
		public sbyte atLeastNbChest { get; set; }
		public ushort skillRequested { get; set; }
		public ulong maxPrice { get; set; }
		public sbyte orderBy { get; set; }

		public HouseToSellFilterMessage(int areaId, sbyte atLeastNbRoom, sbyte atLeastNbChest, ushort skillRequested, ulong maxPrice, sbyte orderBy)
		{
			this.areaId = areaId;
			this.atLeastNbRoom = atLeastNbRoom;
			this.atLeastNbChest = atLeastNbChest;
			this.skillRequested = skillRequested;
			this.maxPrice = maxPrice;
			this.orderBy = orderBy;
		}

		public HouseToSellFilterMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(areaId);
			writer.WriteSByte(atLeastNbRoom);
			writer.WriteSByte(atLeastNbChest);
			writer.WriteVarUShort(skillRequested);
			writer.WriteVarULong(maxPrice);
			writer.WriteSByte(orderBy);
		}

		public override void Deserialize(IDataReader reader)
		{
			areaId = reader.ReadInt();
			atLeastNbRoom = reader.ReadSByte();
			atLeastNbChest = reader.ReadSByte();
			skillRequested = reader.ReadVarUShort();
			maxPrice = reader.ReadVarULong();
			orderBy = reader.ReadSByte();
		}

	}
}
