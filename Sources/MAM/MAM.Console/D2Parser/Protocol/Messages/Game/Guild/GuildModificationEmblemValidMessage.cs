namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildModificationEmblemValidMessage : NetworkMessage
	{
		public const uint Id = 8270;
		public override uint MessageId => Id;
		public GuildEmblem guildEmblem { get; set; }

		public GuildModificationEmblemValidMessage(GuildEmblem guildEmblem)
		{
			this.guildEmblem = guildEmblem;
		}

		public GuildModificationEmblemValidMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			guildEmblem.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			guildEmblem = new GuildEmblem();
			guildEmblem.Deserialize(reader);
		}

	}
}
