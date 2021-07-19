namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractFightTeamInformations
	{
		public const short Id  = 2033;
		public virtual short TypeId => Id;
		public sbyte teamId { get; set; }
		public double leaderId { get; set; }
		public sbyte teamSide { get; set; }
		public sbyte teamTypeId { get; set; }
		public sbyte nbWaves { get; set; }

		public AbstractFightTeamInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves)
		{
			this.teamId = teamId;
			this.leaderId = leaderId;
			this.teamSide = teamSide;
			this.teamTypeId = teamTypeId;
			this.nbWaves = nbWaves;
		}

		public AbstractFightTeamInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(teamId);
			writer.WriteDouble(leaderId);
			writer.WriteSByte(teamSide);
			writer.WriteSByte(teamTypeId);
			writer.WriteSByte(nbWaves);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			teamId = reader.ReadSByte();
			leaderId = reader.ReadDouble();
			teamSide = reader.ReadSByte();
			teamTypeId = reader.ReadSByte();
			nbWaves = reader.ReadSByte();
		}

	}
}
