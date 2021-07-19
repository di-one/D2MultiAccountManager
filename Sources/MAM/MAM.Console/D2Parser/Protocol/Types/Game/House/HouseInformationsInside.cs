namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseInformationsInside : HouseInformations
	{
		public new const short Id = 261;
		public override short TypeId => Id;
		public HouseInstanceInformations houseInfos { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }

		public HouseInformationsInside(uint houseId, ushort modelId, HouseInstanceInformations houseInfos, short worldX, short worldY)
		{
			this.houseId = houseId;
			this.modelId = modelId;
			this.houseInfos = houseInfos;
			this.worldX = worldX;
			this.worldY = worldY;
		}

		public HouseInformationsInside() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(houseInfos.TypeId);
			houseInfos.Serialize(writer);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			houseInfos = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadShort());
			houseInfos.Deserialize(reader);
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
		}

	}
}
