namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInformations : BasicGuildInformations
	{
		public new const short Id = 6465;
		public override short TypeId => Id;
		public GuildEmblem guildEmblem { get; set; }

		public GuildInformations(uint guildId, string guildName, byte guildLevel, GuildEmblem guildEmblem)
		{
			this.guildId = guildId;
			this.guildName = guildName;
			this.guildLevel = guildLevel;
			this.guildEmblem = guildEmblem;
		}

		public GuildInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			guildEmblem.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			guildEmblem = new GuildEmblem();
			guildEmblem.Deserialize(reader);
		}

	}
}
