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
	public class FightTeamInformations : AbstractFightTeamInformations
	{
		public new const short Id = 4316;
		public override short TypeId => Id;
		public IEnumerable<FightTeamMemberInformations> teamMembers { get; set; }

		public FightTeamInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves, IEnumerable<FightTeamMemberInformations> teamMembers)
		{
			this.teamId = teamId;
			this.leaderId = leaderId;
			this.teamSide = teamSide;
			this.teamTypeId = teamTypeId;
			this.nbWaves = nbWaves;
			this.teamMembers = teamMembers;
		}

		public FightTeamInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)teamMembers.Count());
			foreach (var objectToSend in teamMembers)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var teamMembersCount = reader.ReadUShort();
			var teamMembers_ = new FightTeamMemberInformations[teamMembersCount];
			for (var teamMembersIndex = 0; teamMembersIndex < teamMembersCount; teamMembersIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<FightTeamMemberInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				teamMembers_[teamMembersIndex] = objectToAdd;
			}
			teamMembers = teamMembers_;
		}

	}
}
