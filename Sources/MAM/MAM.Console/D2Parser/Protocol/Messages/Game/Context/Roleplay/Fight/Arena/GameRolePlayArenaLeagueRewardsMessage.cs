namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayArenaLeagueRewardsMessage : NetworkMessage
	{
		public const uint Id = 9130;
		public override uint MessageId => Id;
		public ushort seasonId { get; set; }
		public ushort leagueId { get; set; }
		public int ladderPosition { get; set; }
		public bool endSeasonReward { get; set; }

		public GameRolePlayArenaLeagueRewardsMessage(ushort seasonId, ushort leagueId, int ladderPosition, bool endSeasonReward)
		{
			this.seasonId = seasonId;
			this.leagueId = leagueId;
			this.ladderPosition = ladderPosition;
			this.endSeasonReward = endSeasonReward;
		}

		public GameRolePlayArenaLeagueRewardsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(seasonId);
			writer.WriteVarUShort(leagueId);
			writer.WriteInt(ladderPosition);
			writer.WriteBoolean(endSeasonReward);
		}

		public override void Deserialize(IDataReader reader)
		{
			seasonId = reader.ReadVarUShort();
			leagueId = reader.ReadVarUShort();
			ladderPosition = reader.ReadInt();
			endSeasonReward = reader.ReadBoolean();
		}

	}
}
