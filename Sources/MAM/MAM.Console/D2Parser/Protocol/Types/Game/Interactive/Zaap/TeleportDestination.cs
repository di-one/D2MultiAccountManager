namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TeleportDestination
	{
		public const short Id  = 3506;
		public virtual short TypeId => Id;
		public sbyte type { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }
		public ushort level { get; set; }
		public ushort cost { get; set; }

		public TeleportDestination(sbyte type, double mapId, ushort subAreaId, ushort level, ushort cost)
		{
			this.type = type;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
			this.level = level;
			this.cost = cost;
		}

		public TeleportDestination() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(type);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
			writer.WriteVarUShort(level);
			writer.WriteVarUShort(cost);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			type = reader.ReadSByte();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
			level = reader.ReadVarUShort();
			cost = reader.ReadVarUShort();
		}

	}
}
