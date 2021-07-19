namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatServerCopyMessage : ChatAbstractServerMessage
	{
		public new const uint Id = 4685;
		public override uint MessageId => Id;
		public ulong receiverId { get; set; }
		public string receiverName { get; set; }

		public ChatServerCopyMessage(sbyte channel, string content, int timestamp, string fingerprint, ulong receiverId, string receiverName)
		{
			this.channel = channel;
			this.content = content;
			this.timestamp = timestamp;
			this.fingerprint = fingerprint;
			this.receiverId = receiverId;
			this.receiverName = receiverName;
		}

		public ChatServerCopyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(receiverId);
			writer.WriteUTF(receiverName);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			receiverId = reader.ReadVarULong();
			receiverName = reader.ReadUTF();
		}

	}
}
