namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorBasicInformations
	{
		public const short Id  = 7654;
		public virtual short TypeId => Id;
		public ushort firstNameId { get; set; }
		public ushort lastNameId { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }

		public TaxCollectorBasicInformations(ushort firstNameId, ushort lastNameId, short worldX, short worldY, double mapId, ushort subAreaId)
		{
			this.firstNameId = firstNameId;
			this.lastNameId = lastNameId;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
		}

		public TaxCollectorBasicInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(firstNameId);
			writer.WriteVarUShort(lastNameId);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			firstNameId = reader.ReadVarUShort();
			lastNameId = reader.ReadVarUShort();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
		}

	}
}
