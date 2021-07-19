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
	public class FriendOnlineInformations : FriendInformations
	{
		public new const short Id = 6842;
		public override short TypeId => Id;
		public bool sex { get; set; }
		public bool havenBagShared { get; set; }
		public ulong playerId { get; set; }
		public string playerName { get; set; }
		public ushort level { get; set; }
		public sbyte alignmentSide { get; set; }
		public sbyte breed { get; set; }
		public GuildInformations guildInfo { get; set; }
		public ushort moodSmileyId { get; set; }
		public PlayerStatus status { get; set; }

		public FriendOnlineInformations(int accountId, AccountTagInformation accountTag, sbyte playerState, ushort lastConnection, int achievementPoints, short leagueId, int ladderPosition, bool sex, bool havenBagShared, ulong playerId, string playerName, ushort level, sbyte alignmentSide, sbyte breed, GuildInformations guildInfo, ushort moodSmileyId, PlayerStatus status)
		{
			this.accountId = accountId;
			this.accountTag = accountTag;
			this.playerState = playerState;
			this.lastConnection = lastConnection;
			this.achievementPoints = achievementPoints;
			this.leagueId = leagueId;
			this.ladderPosition = ladderPosition;
			this.sex = sex;
			this.havenBagShared = havenBagShared;
			this.playerId = playerId;
			this.playerName = playerName;
			this.level = level;
			this.alignmentSide = alignmentSide;
			this.breed = breed;
			this.guildInfo = guildInfo;
			this.moodSmileyId = moodSmileyId;
			this.status = status;
		}

		public FriendOnlineInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, sex);
			flag = BooleanByteWrapper.SetFlag(flag, 1, havenBagShared);
			writer.WriteByte(flag);
			writer.WriteVarULong(playerId);
			writer.WriteUTF(playerName);
			writer.WriteVarUShort(level);
			writer.WriteSByte(alignmentSide);
			writer.WriteSByte(breed);
			guildInfo.Serialize(writer);
			writer.WriteVarUShort(moodSmileyId);
			writer.WriteShort(status.TypeId);
			status.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var flag = reader.ReadByte();
			sex = BooleanByteWrapper.GetFlag(flag, 0);
			havenBagShared = BooleanByteWrapper.GetFlag(flag, 1);
			playerId = reader.ReadVarULong();
			playerName = reader.ReadUTF();
			level = reader.ReadVarUShort();
			alignmentSide = reader.ReadSByte();
			breed = reader.ReadSByte();
			guildInfo = new GuildInformations();
			guildInfo.Deserialize(reader);
			moodSmileyId = reader.ReadVarUShort();
			status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
			status.Deserialize(reader);
		}

	}
}
