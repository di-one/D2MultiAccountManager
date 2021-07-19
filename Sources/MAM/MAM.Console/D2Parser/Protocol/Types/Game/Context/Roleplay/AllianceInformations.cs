namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceInformations : BasicNamedAllianceInformations
	{
		public new const short Id = 1398;
		public override short TypeId => Id;
		public GuildEmblem allianceEmblem { get; set; }

		public AllianceInformations(uint allianceId, string allianceTag, string allianceName, GuildEmblem allianceEmblem)
		{
			this.allianceId = allianceId;
			this.allianceTag = allianceTag;
			this.allianceName = allianceName;
			this.allianceEmblem = allianceEmblem;
		}

		public AllianceInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			allianceEmblem.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			allianceEmblem = new GuildEmblem();
			allianceEmblem.Deserialize(reader);
		}

	}
}
