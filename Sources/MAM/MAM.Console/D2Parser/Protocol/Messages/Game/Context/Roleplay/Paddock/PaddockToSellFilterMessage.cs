namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockToSellFilterMessage : NetworkMessage
	{
		public const uint Id = 8923;
		public override uint MessageId => Id;
		public int areaId { get; set; }
		public sbyte atLeastNbMount { get; set; }
		public sbyte atLeastNbMachine { get; set; }
		public ulong maxPrice { get; set; }
		public sbyte orderBy { get; set; }

		public PaddockToSellFilterMessage(int areaId, sbyte atLeastNbMount, sbyte atLeastNbMachine, ulong maxPrice, sbyte orderBy)
		{
			this.areaId = areaId;
			this.atLeastNbMount = atLeastNbMount;
			this.atLeastNbMachine = atLeastNbMachine;
			this.maxPrice = maxPrice;
			this.orderBy = orderBy;
		}

		public PaddockToSellFilterMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(areaId);
			writer.WriteSByte(atLeastNbMount);
			writer.WriteSByte(atLeastNbMachine);
			writer.WriteVarULong(maxPrice);
			writer.WriteSByte(orderBy);
		}

		public override void Deserialize(IDataReader reader)
		{
			areaId = reader.ReadInt();
			atLeastNbMount = reader.ReadSByte();
			atLeastNbMachine = reader.ReadSByte();
			maxPrice = reader.ReadVarULong();
			orderBy = reader.ReadSByte();
		}

	}
}
