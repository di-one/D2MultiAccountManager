namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismGeolocalizedInformation : PrismSubareaEmptyInfo
	{
		public new const short Id = 3408;
		public override short TypeId => Id;
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public PrismInformation prism { get; set; }

		public PrismGeolocalizedInformation(ushort subAreaId, uint allianceId, short worldX, short worldY, double mapId, PrismInformation prism)
		{
			this.subAreaId = subAreaId;
			this.allianceId = allianceId;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.prism = prism;
		}

		public PrismGeolocalizedInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteShort(prism.TypeId);
			prism.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			prism = ProtocolTypeManager.GetInstance<PrismInformation>(reader.ReadShort());
			prism.Deserialize(reader);
		}

	}
}
