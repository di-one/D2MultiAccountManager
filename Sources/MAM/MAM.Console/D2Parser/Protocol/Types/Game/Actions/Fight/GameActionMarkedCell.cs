namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionMarkedCell
	{
		public const short Id  = 3828;
		public virtual short TypeId => Id;
		public ushort cellId { get; set; }
		public sbyte zoneSize { get; set; }
		public int cellColor { get; set; }
		public sbyte cellsType { get; set; }

		public GameActionMarkedCell(ushort cellId, sbyte zoneSize, int cellColor, sbyte cellsType)
		{
			this.cellId = cellId;
			this.zoneSize = zoneSize;
			this.cellColor = cellColor;
			this.cellsType = cellsType;
		}

		public GameActionMarkedCell() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(cellId);
			writer.WriteSByte(zoneSize);
			writer.WriteInt(cellColor);
			writer.WriteSByte(cellsType);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			cellId = reader.ReadVarUShort();
			zoneSize = reader.ReadSByte();
			cellColor = reader.ReadInt();
			cellsType = reader.ReadSByte();
		}

	}
}
