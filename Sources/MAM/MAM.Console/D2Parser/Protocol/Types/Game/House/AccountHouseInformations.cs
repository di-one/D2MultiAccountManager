namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AccountHouseInformations : HouseInformations
	{
		public new const short Id = 5019;
		public override short TypeId => Id;
		public HouseInstanceInformations houseInfos { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }

		public AccountHouseInformations(uint houseId, ushort modelId, HouseInstanceInformations houseInfos, short worldX, short worldY, double mapId, ushort subAreaId)
		{
			this.houseId = houseId;
			this.modelId = modelId;
			this.houseInfos = houseInfos;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
		}

		public AccountHouseInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(houseInfos.TypeId);
			houseInfos.Serialize(writer);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			houseInfos = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadShort());
			houseInfos.Deserialize(reader);
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
		}

	}
}
