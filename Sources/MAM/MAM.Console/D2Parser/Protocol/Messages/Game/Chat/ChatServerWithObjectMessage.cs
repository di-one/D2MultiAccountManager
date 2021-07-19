namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatServerWithObjectMessage : ChatServerMessage
	{
		public new const uint Id = 5393;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItem> objects { get; set; }

		public ChatServerWithObjectMessage(sbyte channel, string content, int timestamp, string fingerprint, double senderId, string senderName, string prefix, int senderAccountId, IEnumerable<ObjectItem> objects)
		{
			this.channel = channel;
			this.content = content;
			this.timestamp = timestamp;
			this.fingerprint = fingerprint;
			this.senderId = senderId;
			this.senderName = senderName;
			this.prefix = prefix;
			this.senderAccountId = senderAccountId;
			this.objects = objects;
		}

		public ChatServerWithObjectMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)objects.Count());
			foreach (var objectToSend in objects)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var objectsCount = reader.ReadUShort();
			var objects_ = new ObjectItem[objectsCount];
			for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
			{
				var objectToAdd = new ObjectItem();
				objectToAdd.Deserialize(reader);
				objects_[objectsIndex] = objectToAdd;
			}
			objects = objects_;
		}

	}
}
