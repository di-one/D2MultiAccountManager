namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendSpouseOnlineInformations : FriendSpouseInformations
	{
		public new const short Id = 6899;
		public override short TypeId => Id;
		public bool inFight { get; set; }
		public bool followSpouse { get; set; }
		public double mapId { get; set; }
		public ushort subAreaId { get; set; }

		public FriendSpouseOnlineInformations(int spouseAccountId, ulong spouseId, string spouseName, ushort spouseLevel, sbyte breed, sbyte sex, EntityLook spouseEntityLook, GuildInformations guildInfo, sbyte alignmentSide, bool inFight, bool followSpouse, double mapId, ushort subAreaId)
		{
			this.spouseAccountId = spouseAccountId;
			this.spouseId = spouseId;
			this.spouseName = spouseName;
			this.spouseLevel = spouseLevel;
			this.breed = breed;
			this.sex = sex;
			this.spouseEntityLook = spouseEntityLook;
			this.guildInfo = guildInfo;
			this.alignmentSide = alignmentSide;
			this.inFight = inFight;
			this.followSpouse = followSpouse;
			this.mapId = mapId;
			this.subAreaId = subAreaId;
		}

		public FriendSpouseOnlineInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, inFight);
			flag = BooleanByteWrapper.SetFlag(flag, 1, followSpouse);
			writer.WriteByte(flag);
			writer.WriteDouble(mapId);
			writer.WriteVarUShort(subAreaId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var flag = reader.ReadByte();
			inFight = BooleanByteWrapper.GetFlag(flag, 0);
			followSpouse = BooleanByteWrapper.GetFlag(flag, 1);
			mapId = reader.ReadDouble();
			subAreaId = reader.ReadVarUShort();
		}

	}
}
