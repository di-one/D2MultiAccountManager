namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceBulletinSetRequestMessage : SocialNoticeSetRequestMessage
	{
		public new const uint Id = 4103;
		public override uint MessageId => Id;
		public string content { get; set; }
		public bool notifyMembers { get; set; }

		public AllianceBulletinSetRequestMessage(string content, bool notifyMembers)
		{
			this.content = content;
			this.notifyMembers = notifyMembers;
		}

		public AllianceBulletinSetRequestMessage() { }

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
