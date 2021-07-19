namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ArenaRanking
	{
		public const short Id  = 9682;
		public virtual short TypeId => Id;
		public ushort rank { get; set; }
		public ushort bestRank { get; set; }

		public ArenaRanking(ushort rank, ushort bestRank)
		{
			this.rank = rank;
			this.bestRank = bestRank;
		}

		public ArenaRanking() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(rank);
			writer.WriteVarUShort(bestRank);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			rank = reader.ReadVarUShort();
			bestRank = reader.ReadVarUShort();
		}

	}
}
