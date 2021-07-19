namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceFactSheetInformations : AllianceInformations
	{
		public new const short Id = 7735;
		public override short TypeId => Id;
		public int creationDate { get; set; }

		public AllianceFactSheetInformations(uint allianceId, string allianceTag, string allianceName, GuildEmblem allianceEmblem, int creationDate)
		{
			this.allianceId = allianceId;
			this.allianceTag = allianceTag;
			this.allianceName = allianceName;
			this.allianceEmblem = allianceEmblem;
			this.creationDate = creationDate;
		}

		public AllianceFactSheetInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(creationDate);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			creationDate = reader.ReadInt();
		}

	}
}
