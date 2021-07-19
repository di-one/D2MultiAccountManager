namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ArenaLeagueRanking
	{
		public const short Id  = 9583;
		public virtual short TypeId => Id;
		public ushort rank { get; set; }
		public ushort leagueId { get; set; }
		public short leaguePoints { get; set; }
		public short totalLeaguePoints { get; set; }
		public int ladderPosition { get; set; }

		public ArenaLeagueRanking(ushort rank, ushort leagueId, short leaguePoints, short totalLeaguePoints, int ladderPosition)
		{
			this.rank = rank;
			this.leagueId = leagueId;
			this.leaguePoints = leaguePoints;
			this.totalLeaguePoints = totalLeaguePoints;
			this.ladderPosition = ladderPosition;
		}

		public ArenaLeagueRanking() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(rank);
			writer.WriteVarUShort(leagueId);
			writer.WriteVarShort(leaguePoints);
			writer.WriteVarShort(totalLeaguePoints);
			writer.WriteInt(ladderPosition);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			rank = reader.ReadVarUShort();
			leagueId = reader.ReadVarUShort();
			leaguePoints = reader.ReadVarShort();
			totalLeaguePoints = reader.ReadVarShort();
			ladderPosition = reader.ReadInt();
		}

	}
}
