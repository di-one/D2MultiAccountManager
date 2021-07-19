namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildJoinedMessage : NetworkMessage
	{
		public const uint Id = 8890;
		public override uint MessageId => Id;
		public GuildInformations guildInfo { get; set; }
		public uint memberRights { get; set; }

		public GuildJoinedMessage(GuildInformations guildInfo, uint memberRights)
		{
			this.guildInfo = guildInfo;
			this.memberRights = memberRights;
		}

		public GuildJoinedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			guildInfo.Serialize(writer);
			writer.WriteVarUInt(memberRights);
		}

		public override void Deserialize(IDataReader reader)
		{
			guildInfo = new GuildInformations();
			guildInfo.Deserialize(reader);
			memberRights = reader.ReadVarUInt();
		}

	}
}
