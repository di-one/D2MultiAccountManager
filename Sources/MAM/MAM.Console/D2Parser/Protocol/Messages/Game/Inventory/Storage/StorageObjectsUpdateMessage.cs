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
	public class StorageObjectsUpdateMessage : NetworkMessage
	{
		public const uint Id = 2221;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItem> objectList { get; set; }

		public StorageObjectsUpdateMessage(IEnumerable<ObjectItem> objectList)
		{
			this.objectList = objectList;
		}

		public StorageObjectsUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)objectList.Count());
			foreach (var objectToSend in objectList)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var objectListCount = reader.ReadUShort();
			var objectList_ = new ObjectItem[objectListCount];
			for (var objectListIndex = 0; objectListIndex < objectListCount; objectListIndex++)
			{
				var objectToAdd = new ObjectItem();
				objectToAdd.Deserialize(reader);
				objectList_[objectListIndex] = objectToAdd;
			}
			objectList = objectList_;
		}

	}
}
