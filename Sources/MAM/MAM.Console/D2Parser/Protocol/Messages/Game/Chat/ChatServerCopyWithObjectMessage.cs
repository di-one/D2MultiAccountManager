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
	public class ChatServerCopyWithObjectMessage : ChatServerCopyMessage
	{
		public new const uint Id = 4950;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItem> objects { get; set; }

		public ChatServerCopyWithObjectMessage(sbyte channel, string content, int timestamp, string fingerprint, ulong receiverId, string receiverName, IEnumerable<ObjectItem> objects)
		{
			this.channel = channel;
			this.content = content;
			this.timestamp = timestamp;
			this.fingerprint = fingerprint;
			this.receiverId = receiverId;
			this.receiverName = receiverName;
			this.objects = objects;
		}

		public ChatServerCopyWithObjectMessage() { }

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
