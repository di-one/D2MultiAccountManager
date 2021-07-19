namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildModificationValidMessage : NetworkMessage
	{
		public const uint Id = 434;
		public override uint MessageId => Id;
		public string guildName { get; set; }
		public GuildEmblem guildEmblem { get; set; }

		public GuildModificationValidMessage(string guildName, GuildEmblem guildEmblem)
		{
			this.guildName = guildName;
			this.guildEmblem = guildEmblem;
		}

		public GuildModificationValidMessage() { }

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
