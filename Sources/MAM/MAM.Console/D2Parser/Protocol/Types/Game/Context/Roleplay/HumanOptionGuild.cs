namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HumanOptionGuild : HumanOption
	{
		public new const short Id = 7748;
		public override short TypeId => Id;
		public GuildInformations guildInformations { get; set; }

		public HumanOptionGuild(GuildInformations guildInformations)
		{
			this.guildInformations = guildInformations;
		}

		public HumanOptionGuild() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			guildInformations.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			guildInformations = new GuildInformations();
			guildInformations.Deserialize(reader);
		}

	}
}
