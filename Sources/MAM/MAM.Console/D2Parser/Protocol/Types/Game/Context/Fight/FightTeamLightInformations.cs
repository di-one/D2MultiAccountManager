namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTeamLightInformations : AbstractFightTeamInformations
	{
		public new const short Id = 1116;
		public override short TypeId => Id;
		public bool hasFriend { get; set; }
		public bool hasGuildMember { get; set; }
		public bool hasAllianceMember { get; set; }
		public bool hasGroupMember { get; set; }
		public bool hasMyTaxCollector { get; set; }
		public sbyte teamMembersCount { get; set; }
		public uint meanLevel { get; set; }

		public FightTeamLightInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves, bool hasFriend, bool hasGuildMember, bool hasAllianceMember, bool hasGroupMember, bool hasMyTaxCollector, sbyte teamMembersCount, uint meanLevel)
		{
			this.teamId = teamId;
			this.leaderId = leaderId;
			this.teamSide = teamSide;
			this.teamTypeId = teamTypeId;
			this.nbWaves = nbWaves;
			this.hasFriend = hasFriend;
			this.hasGuildMember = hasGuildMember;
			this.hasAllianceMember = hasAllianceMember;
			this.hasGroupMember = hasGroupMember;
			this.hasMyTaxCollector = hasMyTaxCollector;
			this.teamMembersCount = teamMembersCount;
			this.meanLevel = meanLevel;
		}

		public FightTeamLightInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, hasFriend);
			flag = BooleanByteWrapper.SetFlag(flag, 1, hasGuildMember);
			flag = BooleanByteWrapper.SetFlag(flag, 2, hasAllianceMember);
			flag = BooleanByteWrapper.SetFlag(flag, 3, hasGroupMember);
			flag = BooleanByteWrapper.SetFlag(flag, 4, hasMyTaxCollector);
			writer.WriteByte(flag);
			writer.WriteSByte(teamMembersCount);
			writer.WriteVarUInt(meanLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var flag = reader.ReadByte();
			hasFriend = BooleanByteWrapper.GetFlag(flag, 0);
			hasGuildMember = BooleanByteWrapper.GetFlag(flag, 1);
			hasAllianceMember = BooleanByteWrapper.GetFlag(flag, 2);
			hasGroupMember = BooleanByteWrapper.GetFlag(flag, 3);
			hasMyTaxCollector = BooleanByteWrapper.GetFlag(flag, 4);
			teamMembersCount = reader.ReadSByte();
			meanLevel = reader.ReadVarUInt();
		}

	}
}
