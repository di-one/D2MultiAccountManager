namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceMotdSetRequestMessage : SocialNoticeSetRequestMessage
	{
		public new const uint Id = 6887;
		public override uint MessageId => Id;
		public string content { get; set; }

		public AllianceMotdSetRequestMessage(string content)
		{
			this.content = content;
		}

		public AllianceMotdSetRequestMessage() { }

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
