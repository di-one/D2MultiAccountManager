namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Protocol.Enums;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobCrafterDirectoryEntryPlayerInfo
	{
		public const short Id  = 5492;
		public virtual short TypeId => Id;
		public ulong playerId { get; set; }
		public string playerName { get; set; }
		public sbyte alignmentSide { get; set; }
		public sbyte breed { get; set; }
		public bool sex { get; set; }
		public bool isInWorkshop { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }
		public bool canCraftLegendary { get; set; }
		public PlayerStatus status { get; set; }

		public JobCrafterDirectoryEntryPlayerInfo(ulong playerId, string playerName, sbyte alignmentSide, sbyte breed, bool sex, bool isInWorkshop, short worldX, short worldY, double mapId, ushort subAreaId, bool canCraftLegendary, PlayerStatus status)
		{
			this.playerId = playerId;
			this.playerName = playerName;
			this.alignmentSide = alignmentSide;
			this.breed = breed;
			this.sex = sex;
			this.isInWorkshop = isInWorkshop;
			this.worldX = worldX;
			this.worldY = worldY;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
			this.canCraftLegendary = canCraftLegendary;
			this.status = status;
		}

		public JobCrafterDirectoryEntryPlayerInfo() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(playerId);
			writer.WriteUTF(playerName);
			writer.WriteSByte(alignmentSide);
			writer.WriteSByte(breed);
			writer.WriteBoolean(sex);
			writer.WriteBoolean(isInWorkshop);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
			writer.WriteBoolean(canCraftLegendary);
			writer.WriteShort(status.TypeId);
			status.Serialize(writer);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			playerId = reader.ReadVarULong();
			playerName = reader.ReadUTF();
			alignmentSide = reader.ReadSByte();
			breed = reader.ReadSByte();
			sex = reader.ReadBoolean();
			isInWorkshop = reader.ReadBoolean();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
			canCraftLegendary = reader.ReadBoolean();
			status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
			status.Deserialize(reader);
		}

	}
}
