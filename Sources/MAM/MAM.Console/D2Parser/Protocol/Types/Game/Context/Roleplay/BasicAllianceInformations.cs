namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicAllianceInformations : AbstractSocialGroupInfos
	{
		public new const short Id = 3126;
		public override short TypeId => Id;
		public uint allianceId { get; set; }
		public string allianceTag { get; set; }

		public BasicAllianceInformations(uint allianceId, string allianceTag)
		{
			this.allianceId = allianceId;
			this.allianceTag = allianceTag;
		}

		public BasicAllianceInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(allianceId);
			writer.WriteUTF(allianceTag);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			allianceId = reader.ReadVarUInt();
			allianceTag = reader.ReadUTF();
		}

	}
}
