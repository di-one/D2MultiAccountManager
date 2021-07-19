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
	public class InventoryContentMessage : NetworkMessage
	{
		public const uint Id = 4723;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItem> objects { get; set; }
		public ulong kamas { get; set; }

		public InventoryContentMessage(IEnumerable<ObjectItem> objects, ulong kamas)
		{
			this.objects = objects;
			this.kamas = kamas;
		}

		public InventoryContentMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)objects.Count());
			foreach (var objectToSend in objects)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteVarULong(kamas);
		}

		public override void Deserialize(IDataReader reader)
		{
			var objectsCount = reader.ReadUShort();
			var objects_ = new ObjectItem[objectsCount];
			for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
			{
				var objectToAdd = new ObjectItem();
				objectToAdd.Deserialize(reader);
				objects_[objectsIndex] = objectToAdd;
			}
			objects = objects_;
			kamas = reader.ReadVarULong();
		}

	}
}
