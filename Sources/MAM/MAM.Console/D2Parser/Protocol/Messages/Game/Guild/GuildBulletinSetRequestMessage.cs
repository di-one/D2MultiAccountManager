namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildBulletinSetRequestMessage : SocialNoticeSetRequestMessage
	{
		public new const uint Id = 7267;
		public override uint MessageId => Id;
		public string content { get; set; }
		public bool notifyMembers { get; set; }

		public GuildBulletinSetRequestMessage(string content, bool notifyMembers)
		{
			this.content = content;
			this.notifyMembers = notifyMembers;
		}

		public GuildBulletinSetRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(content);
			writer.WriteBoolean(notifyMembers);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			content = reader.ReadUTF();
			notifyMembers = reader.ReadBoolean();
		}

	}
}
