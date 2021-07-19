namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInAllianceFactsMessage : GuildFactsMessage
	{
		public new const uint Id = 8547;
		public override uint MessageId => Id;
		public BasicNamedAllianceInformations allianceInfos { get; set; }

		public GuildInAllianceFactsMessage(GuildFactSheetInformations infos, int creationDate, ushort nbTaxCollectors, IEnumerable<CharacterMinimalGuildPublicInformations> members, BasicNamedAllianceInformations allianceInfos)
		{
			this.infos = infos;
			this.creationDate = creationDate;
			this.nbTaxCollectors = nbTaxCollectors;
			this.members = members;
			this.allianceInfos = allianceInfos;
		}

		public GuildInAllianceFactsMessage() { }

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
