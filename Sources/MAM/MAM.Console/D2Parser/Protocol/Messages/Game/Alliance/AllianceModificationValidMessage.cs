namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceModificationValidMessage : NetworkMessage
	{
		public const uint Id = 9803;
		public override uint MessageId => Id;
		public string allianceName { get; set; }
		public string allianceTag { get; set; }
		public GuildEmblem Alliancemblem { get; set; }

		public AllianceModificationValidMessage(string allianceName, string allianceTag, GuildEmblem Alliancemblem)
		{
			this.allianceName = allianceName;
			this.allianceTag = allianceTag;
			this.Alliancemblem = Alliancemblem;
		}

		public AllianceModificationValidMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(allianceName);
			writer.WriteUTF(allianceTag);
			Alliancemblem.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			allianceName = reader.ReadUTF();
			allianceTag = reader.ReadUTF();
			Alliancemblem = new GuildEmblem();
			Alliancemblem.Deserialize(reader);
		}

	}
}
