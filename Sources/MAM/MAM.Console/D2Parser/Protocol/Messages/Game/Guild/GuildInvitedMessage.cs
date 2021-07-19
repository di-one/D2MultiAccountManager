namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInvitedMessage : NetworkMessage
	{
		public const uint Id = 7256;
		public override uint MessageId => Id;
		public ulong recruterId { get; set; }
		public string recruterName { get; set; }
		public BasicGuildInformations guildInfo { get; set; }

		public GuildInvitedMessage(ulong recruterId, string recruterName, BasicGuildInformations guildInfo)
		{
			this.recruterId = recruterId;
			this.recruterName = recruterName;
			this.guildInfo = guildInfo;
		}

		public GuildInvitedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(recruterId);
			writer.WriteUTF(recruterName);
			guildInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			recruterId = reader.ReadVarULong();
			recruterName = reader.ReadUTF();
			guildInfo = new BasicGuildInformations();
			guildInfo.Deserialize(reader);
		}

	}
}
