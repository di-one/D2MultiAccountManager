namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatAdminServerMessage : ChatServerMessage
	{
		public new const uint Id = 2714;
		public override uint MessageId => Id;

		public ChatAdminServerMessage(sbyte channel, string content, int timestamp, string fingerprint, double senderId, string senderName, string prefix, int senderAccountId)
		{
			this.channel = channel;
			this.content = content;
			this.timestamp = timestamp;
			this.fingerprint = fingerprint;
			this.senderId = senderId;
			this.senderName = senderName;
			this.prefix = prefix;
			this.senderAccountId = senderAccountId;
		}

		public ChatAdminServerMessage() { }

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
