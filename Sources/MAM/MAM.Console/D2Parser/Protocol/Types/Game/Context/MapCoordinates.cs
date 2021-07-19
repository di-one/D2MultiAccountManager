namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MapCoordinates
	{
		public const short Id  = 4951;
		public virtual short TypeId => Id;
		public short worldX { get; set; }
		public short worldY { get; set; }

		public MapCoordinates(short worldX, short worldY)
		{
			this.worldX = worldX;
			this.worldY = worldY;
		}

		public MapCoordinates() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
		}

	}
}
