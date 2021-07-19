namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ArenaRankInfos
	{
		public const short Id  = 9350;
		public virtual short TypeId => Id;
		public ArenaRanking ranking { get; set; }
		public ArenaLeagueRanking leagueRanking { get; set; }
		public ushort victoryCount { get; set; }
		public ushort fightcount { get; set; }
		public short numFightNeededForLadder { get; set; }

		public ArenaRankInfos(ArenaRanking ranking, ArenaLeagueRanking leagueRanking, ushort victoryCount, ushort fightcount, short numFightNeededForLadder)
		{
			this.ranking = ranking;
			this.leagueRanking = leagueRanking;
			this.victoryCount = victoryCount;
			this.fightcount = fightcount;
			this.numFightNeededForLadder = numFightNeededForLadder;
		}

		public ArenaRankInfos() { }

		public virtual void Serialize(IDataWriter writer)
		{
			ranking.Serialize(writer);
			leagueRanking.Serialize(writer);
			writer.WriteVarUShort(victoryCount);
			writer.WriteVarUShort(fightcount);
			writer.WriteShort(numFightNeededForLadder);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			ranking = new ArenaRanking();
			ranking.Deserialize(reader);
			leagueRanking = new ArenaLeagueRanking();
			leagueRanking.Deserialize(reader);
			victoryCount = reader.ReadVarUShort();
			fightcount = reader.ReadVarUShort();
			numFightNeededForLadder = reader.ReadShort();
		}

	}
}
