namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MapCoordinatesAndId : MapCoordinates
	{
		public new const short Id = 992;
		public override short TypeId => Id;
		public double mapId { get; set; }

		public MapCoordinatesAndId(short worldX, short worldY, double mapId)
		{
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
		}

		public MapCoordinatesAndId() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(mapId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			mapId = reader.ReadDouble();
		}

	}
}
