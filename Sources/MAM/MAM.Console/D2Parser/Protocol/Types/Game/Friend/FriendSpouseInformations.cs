namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendSpouseInformations
	{
		public const short Id  = 9186;
		public virtual short TypeId => Id;
		public int spouseAccountId { get; set; }
		public ulong spouseId { get; set; }
		public string spouseName { get; set; }
		public ushort spouseLevel { get; set; }
		public sbyte breed { get; set; }
		public sbyte sex { get; set; }
		public EntityLook spouseEntityLook { get; set; }
		public GuildInformations guildInfo { get; set; }
		public sbyte alignmentSide { get; set; }

		public FriendSpouseInformations(int spouseAccountId, ulong spouseId, string spouseName, ushort spouseLevel, sbyte breed, sbyte sex, EntityLook spouseEntityLook, GuildInformations guildInfo, sbyte alignmentSide)
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
		}

		public FriendSpouseInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(spouseAccountId);
			writer.WriteVarULong(spouseId);
			writer.WriteUTF(spouseName);
			writer.WriteVarUShort(spouseLevel);
			writer.WriteSByte(breed);
			writer.WriteSByte(sex);
			spouseEntityLook.Serialize(writer);
			guildInfo.Serialize(writer);
			writer.WriteSByte(alignmentSide);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			spouseAccountId = reader.ReadInt();
			spouseId = reader.ReadVarULong();
			spouseName = reader.ReadUTF();
			spouseLevel = reader.ReadVarUShort();
			breed = reader.ReadSByte();
			sex = reader.ReadSByte();
			spouseEntityLook = new EntityLook();
			spouseEntityLook.Deserialize(reader);
			guildInfo = new GuildInformations();
			guildInfo.Deserialize(reader);
			alignmentSide = reader.ReadSByte();
		}

	}
}
