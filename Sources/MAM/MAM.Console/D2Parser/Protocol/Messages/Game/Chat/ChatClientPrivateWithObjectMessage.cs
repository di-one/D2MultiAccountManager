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
	public class ChatClientPrivateWithObjectMessage : ChatClientPrivateMessage
	{
		public new const uint Id = 1886;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItem> objects { get; set; }

		public ChatClientPrivateWithObjectMessage(string content, AbstractPlayerSearchInformation receiver, IEnumerable<ObjectItem> objects)
		{
			this.content = content;
			this.receiver = receiver;
			this.objects = objects;
		}

		public ChatClientPrivateWithObjectMessage() { }

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
