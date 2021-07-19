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
	public class LeagueFriendInformations : AbstractContactInformations
	{
		public new const short Id = 8851;
		public override short TypeId => Id;
		public ulong playerId { get; set; }
		public string playerName { get; set; }
		public sbyte breed { get; set; }
		public bool sex { get; set; }
		public ushort level { get; set; }
		public short leagueId { get; set; }
		public short totalLeaguePoints { get; set; }
		public int ladderPosition { get; set; }

		public LeagueFriendInformations(int accountId, AccountTagInformation accountTag, ulong playerId, string playerName, sbyte breed, bool sex, ushort level, short leagueId, short totalLeaguePoints, int ladderPosition)
		{
			this.accountId = accountId;
			this.accountTag = accountTag;
			this.playerId = playerId;
			this.playerName = playerName;
			this.breed = breed;
			this.sex = sex;
			this.level = level;
			this.leagueId = leagueId;
			this.totalLeaguePoints = totalLeaguePoints;
			this.ladderPosition = ladderPosition;
		}

		public LeagueFriendInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(playerId);
			writer.WriteUTF(playerName);
			writer.WriteSByte(breed);
			writer.WriteBoolean(sex);
			writer.WriteVarUShort(level);
			writer.WriteVarShort(leagueId);
			writer.WriteVarShort(totalLeaguePoints);
			writer.WriteInt(ladderPosition);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerId = reader.ReadVarULong();
			playerName = reader.ReadUTF();
			breed = reader.ReadSByte();
			sex = reader.ReadBoolean();
			level = reader.ReadVarUShort();
			leagueId = reader.ReadVarShort();
			totalLeaguePoints = reader.ReadVarShort();
			ladderPosition = reader.ReadInt();
		}

	}
}
