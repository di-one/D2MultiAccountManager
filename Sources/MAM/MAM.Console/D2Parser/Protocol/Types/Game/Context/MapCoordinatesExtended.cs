namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MapCoordinatesExtended : MapCoordinatesAndId
	{
		public new const short Id = 1133;
		public override short TypeId => Id;
		public ushort subAreaId { get; set; }

		public MapCoordinatesExtended(short worldX, short worldY, double mapId, ushort subAreaId)
		{
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
		}

		public MapCoordinatesExtended() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(subAreaId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			subAreaId = reader.ReadVarUShort();
		}

	}
}
