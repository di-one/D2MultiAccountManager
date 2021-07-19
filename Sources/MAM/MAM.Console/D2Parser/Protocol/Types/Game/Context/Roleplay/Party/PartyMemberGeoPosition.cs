namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyMemberGeoPosition
	{
		public const short Id  = 9108;
		public virtual short TypeId => Id;
		public int memberId { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }

		public PartyMemberGeoPosition(int memberId, short worldX, short worldY, double mapId, ushort subAreaId)
		{
			this.memberId = memberId;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
		}

		public PartyMemberGeoPosition() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(memberId);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			memberId = reader.ReadInt();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
		}

	}
}
