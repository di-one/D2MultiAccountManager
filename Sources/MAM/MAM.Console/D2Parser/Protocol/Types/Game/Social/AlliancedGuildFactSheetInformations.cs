namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AlliancedGuildFactSheetInformations : GuildInformations
	{
		public new const short Id = 1184;
		public override short TypeId => Id;
		public BasicNamedAllianceInformations allianceInfos { get; set; }

		public AlliancedGuildFactSheetInformations(uint guildId, string guildName, byte guildLevel, GuildEmblem guildEmblem, BasicNamedAllianceInformations allianceInfos)
		{
			this.guildId = guildId;
			this.guildName = guildName;
			this.guildLevel = guildLevel;
			this.guildEmblem = guildEmblem;
			this.allianceInfos = allianceInfos;
		}

		public AlliancedGuildFactSheetInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			allianceInfos.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			allianceInfos = new BasicNamedAllianceInformations();
			allianceInfos.Deserialize(reader);
		}

	}
}
