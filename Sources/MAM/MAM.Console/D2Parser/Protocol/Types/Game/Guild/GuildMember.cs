namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildMember : CharacterMinimalInformations
	{
		public new const short Id = 4297;
		public override short TypeId => Id;
		public bool sex { get; set; }
		public bool havenBagShared { get; set; }
		public sbyte breed { get; set; }
		public ushort rank { get; set; }
		public ulong givenExperience { get; set; }
		public sbyte experienceGivenPercent { get; set; }
		public uint rights { get; set; }
		public sbyte connected { get; set; }
		public sbyte alignmentSide { get; set; }
		public ushort hoursSinceLastConnection { get; set; }
		public ushort moodSmileyId { get; set; }
		public int accountId { get; set; }
		public int achievementPoints { get; set; }
		public PlayerStatus status { get; set; }

		public GuildMember(ulong objectId, string name, ushort level, bool sex, bool havenBagShared, sbyte breed, ushort rank, ulong givenExperience, sbyte experienceGivenPercent, uint rights, sbyte connected, sbyte alignmentSide, ushort hoursSinceLastConnection, ushort moodSmileyId, int accountId, int achievementPoints, PlayerStatus status)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.sex = sex;
			this.havenBagShared = havenBagShared;
			this.breed = breed;
			this.rank = rank;
			this.givenExperience = givenExperience;
			this.experienceGivenPercent = experienceGivenPercent;
			this.rights = rights;
			this.connected = connected;
			this.alignmentSide = alignmentSide;
			this.hoursSinceLastConnection = hoursSinceLastConnection;
			this.moodSmileyId = moodSmileyId;
			this.accountId = accountId;
			this.achievementPoints = achievementPoints;
			this.status = status;
		}

		public GuildMember() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, sex);
			flag = BooleanByteWrapper.SetFlag(flag, 1, havenBagShared);
			writer.WriteByte(flag);
			writer.WriteSByte(breed);
			writer.WriteVarUShort(rank);
			writer.WriteVarULong(givenExperience);
			writer.WriteSByte(experienceGivenPercent);
			writer.WriteVarUInt(rights);
			writer.WriteSByte(connected);
			writer.WriteSByte(alignmentSide);
			writer.WriteUShort(hoursSinceLastConnection);
			writer.WriteVarUShort(moodSmileyId);
			writer.WriteInt(accountId);
			writer.WriteInt(achievementPoints);
			writer.WriteShort(status.TypeId);
			status.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var flag = reader.ReadByte();
			sex = BooleanByteWrapper.GetFlag(flag, 0);
			havenBagShared = BooleanByteWrapper.GetFlag(flag, 1);
			breed = reader.ReadSByte();
			rank = reader.ReadVarUShort();
			givenExperience = reader.ReadVarULong();
			experienceGivenPercent = reader.ReadSByte();
			rights = reader.ReadVarUInt();
			connected = reader.ReadSByte();
			alignmentSide = reader.ReadSByte();
			hoursSinceLastConnection = reader.ReadUShort();
			moodSmileyId = reader.ReadVarUShort();
			accountId = reader.ReadInt();
			achievementPoints = reader.ReadInt();
			status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
			status.Deserialize(reader);
		}

	}
}
