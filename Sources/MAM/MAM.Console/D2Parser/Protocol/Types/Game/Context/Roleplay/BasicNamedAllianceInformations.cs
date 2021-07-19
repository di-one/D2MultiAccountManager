namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicNamedAllianceInformations : BasicAllianceInformations
	{
		public new const short Id = 56;
		public override short TypeId => Id;
		public string allianceName { get; set; }

		public BasicNamedAllianceInformations(uint allianceId, string allianceTag, string allianceName)
		{
			this.allianceId = allianceId;
			this.allianceTag = allianceTag;
			this.allianceName = allianceName;
		}

		public BasicNamedAllianceInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(allianceName);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			allianceName = reader.ReadUTF();
		}

	}
}
