namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendInformations : AbstractContactInformations
	{
		public new const short Id = 9750;
		public override short TypeId => Id;
		public sbyte playerState { get; set; }
		public ushort lastConnection { get; set; }
		public int achievementPoints { get; set; }
		public short leagueId { get; set; }
		public int ladderPosition { get; set; }

		public FriendInformations(int accountId, AccountTagInformation accountTag, sbyte playerState, ushort lastConnection, int achievementPoints, short leagueId, int ladderPosition)
		{
			this.accountId = accountId;
			this.accountTag = accountTag;
			this.playerState = playerState;
			this.lastConnection = lastConnection;
			this.achievementPoints = achievementPoints;
			this.leagueId = leagueId;
			this.ladderPosition = ladderPosition;
		}

		public FriendInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(playerState);
			writer.WriteVarUShort(lastConnection);
			writer.WriteInt(achievementPoints);
			writer.WriteVarShort(leagueId);
			writer.WriteInt(ladderPosition);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerState = reader.ReadSByte();
			lastConnection = reader.ReadVarUShort();
			achievementPoints = reader.ReadInt();
			leagueId = reader.ReadVarShort();
			ladderPosition = reader.ReadInt();
		}

	}
}
