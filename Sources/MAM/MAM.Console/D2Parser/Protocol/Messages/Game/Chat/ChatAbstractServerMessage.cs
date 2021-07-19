namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatAbstractServerMessage : NetworkMessage
	{
		public const uint Id = 7258;
		public override uint MessageId => Id;
		public sbyte channel { get; set; }
		public string content { get; set; }
		public int timestamp { get; set; }
		public string fingerprint { get; set; }

		public ChatAbstractServerMessage(sbyte channel, string content, int timestamp, string fingerprint)
		{
			this.channel = channel;
			this.content = content;
			this.timestamp = timestamp;
			this.fingerprint = fingerprint;
		}

		public ChatAbstractServerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(channel);
			writer.WriteUTF(content);
			writer.WriteInt(timestamp);
			writer.WriteUTF(fingerprint);
		}

		public override void Deserialize(IDataReader reader)
		{
			channel = reader.ReadSByte();
			content = reader.ReadUTF();
			timestamp = reader.ReadInt();
			fingerprint = reader.ReadUTF();
		}

	}
}
