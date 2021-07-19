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
	public class StorageObjectsRemoveMessage : NetworkMessage
	{
		public const uint Id = 2935;
		public override uint MessageId => Id;
		public IEnumerable<uint> objectUIDList { get; set; }

		public StorageObjectsRemoveMessage(IEnumerable<uint> objectUIDList)
		{
			this.objectUIDList = objectUIDList;
		}

		public StorageObjectsRemoveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)objectUIDList.Count());
			foreach (var objectToSend in objectUIDList)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var objectUIDListCount = reader.ReadUShort();
			var objectUIDList_ = new uint[objectUIDListCount];
			for (var objectUIDListIndex = 0; objectUIDListIndex < objectUIDListCount; objectUIDListIndex++)
			{
				objectUIDList_[objectUIDListIndex] = reader.ReadVarUInt();
			}
			objectUIDList = objectUIDList_;
		}

	}
}
