namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildCreationValidMessage : NetworkMessage
	{
		public const uint Id = 9369;
		public override uint MessageId => Id;
		public string guildName { get; set; }
		public GuildEmblem guildEmblem { get; set; }

		public GuildCreationValidMessage(string guildName, GuildEmblem guildEmblem)
		{
			this.guildName = guildName;
			this.guildEmblem = guildEmblem;
		}

		public GuildCreationValidMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(guildName);
			guildEmblem.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			guildName = reader.ReadUTF();
			guildEmblem = new GuildEmblem();
			guildEmblem.Deserialize(reader);
		}

	}
}
