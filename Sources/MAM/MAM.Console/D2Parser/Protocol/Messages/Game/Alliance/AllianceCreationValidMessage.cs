namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceCreationValidMessage : NetworkMessage
	{
		public const uint Id = 9500;
		public override uint MessageId => Id;
		public string allianceName { get; set; }
		public string allianceTag { get; set; }
		public GuildEmblem allianceEmblem { get; set; }

		public AllianceCreationValidMessage(string allianceName, string allianceTag, GuildEmblem allianceEmblem)
		{
			this.allianceName = allianceName;
			this.allianceTag = allianceTag;
			this.allianceEmblem = allianceEmblem;
		}

		public AllianceCreationValidMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(allianceName);
			writer.WriteUTF(allianceTag);
			allianceEmblem.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			allianceName = reader.ReadUTF();
			allianceTag = reader.ReadUTF();
			allianceEmblem = new GuildEmblem();
			allianceEmblem.Deserialize(reader);
		}

	}
}
