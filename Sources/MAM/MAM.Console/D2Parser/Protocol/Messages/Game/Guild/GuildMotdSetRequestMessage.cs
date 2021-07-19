namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildMotdSetRequestMessage : SocialNoticeSetRequestMessage
	{
		public new const uint Id = 7492;
		public override uint MessageId => Id;
		public string content { get; set; }

		public GuildMotdSetRequestMessage(string content)
		{
			this.content = content;
		}

		public GuildMotdSetRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(content);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			content = reader.ReadUTF();
		}

	}
}
