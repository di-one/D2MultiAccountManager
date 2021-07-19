namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceModificationNameAndTagValidMessage : NetworkMessage
	{
		public const uint Id = 1430;
		public override uint MessageId => Id;
		public string allianceName { get; set; }
		public string allianceTag { get; set; }

		public AllianceModificationNameAndTagValidMessage(string allianceName, string allianceTag)
		{
			this.allianceName = allianceName;
			this.allianceTag = allianceTag;
		}

		public AllianceModificationNameAndTagValidMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(allianceName);
			writer.WriteUTF(allianceTag);
		}

		public override void Deserialize(IDataReader reader)
		{
			allianceName = reader.ReadUTF();
			allianceTag = reader.ReadUTF();
		}

	}
}
