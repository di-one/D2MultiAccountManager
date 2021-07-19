namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightAllianceTeamInformations : FightTeamInformations
	{
		public new const short Id = 2474;
		public override short TypeId => Id;
		public sbyte relation { get; set; }

		public FightAllianceTeamInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves, IEnumerable<FightTeamMemberInformations> teamMembers, sbyte relation)
		{
			this.teamId = teamId;
			this.leaderId = leaderId;
			this.teamSide = teamSide;
			this.teamTypeId = teamTypeId;
			this.nbWaves = nbWaves;
			this.teamMembers = teamMembers;
			this.relation = relation;
		}

		public FightAllianceTeamInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(relation);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			relation = reader.ReadSByte();
		}

	}
}
