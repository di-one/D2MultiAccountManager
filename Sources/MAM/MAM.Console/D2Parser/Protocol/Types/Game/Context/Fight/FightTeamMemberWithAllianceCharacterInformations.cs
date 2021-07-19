namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTeamMemberWithAllianceCharacterInformations : FightTeamMemberCharacterInformations
	{
		public new const short Id = 3733;
		public override short TypeId => Id;
		public BasicAllianceInformations allianceInfos { get; set; }

		public FightTeamMemberWithAllianceCharacterInformations(double objectId, string name, ushort level, BasicAllianceInformations allianceInfos)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.allianceInfos = allianceInfos;
		}

		public FightTeamMemberWithAllianceCharacterInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			allianceInfos.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			allianceInfos = new BasicAllianceInformations();
			allianceInfos.Deserialize(reader);
		}

	}
}
