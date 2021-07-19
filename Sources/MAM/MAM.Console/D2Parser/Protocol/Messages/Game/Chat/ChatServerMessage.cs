namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatServerMessage : ChatAbstractServerMessage
	{
		public new const uint Id = 5855;
		public override uint MessageId => Id;
		public double senderId { get; set; }
		public string senderName { get; set; }
		public string prefix { get; set; }
		public int senderAccountId { get; set; }

		public ChatServerMessage(sbyte channel, string content, int timestamp, string fingerprint, double senderId, string senderName, string prefix, int senderAccountId)
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

		public ChatServerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(senderId);
			writer.WriteUTF(senderName);
			writer.WriteUTF(prefix);
			writer.WriteInt(senderAccountId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			senderId = reader.ReadDouble();
			senderName = reader.ReadUTF();
			prefix = reader.ReadUTF();
			senderAccountId = reader.ReadInt();
		}

	}
}
