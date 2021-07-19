namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildMembershipMessage : GuildJoinedMessage
	{
		public new const uint Id = 8256;
		public override uint MessageId => Id;

		public GuildMembershipMessage(GuildInformations guildInfo, uint memberRights)
		{
			this.guildInfo = guildInfo;
			this.memberRights = memberRights;
		}

		public GuildMembershipMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
