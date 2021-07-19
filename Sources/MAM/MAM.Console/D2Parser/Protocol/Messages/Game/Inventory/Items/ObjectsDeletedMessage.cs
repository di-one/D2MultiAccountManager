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
	public class ObjectsDeletedMessage : NetworkMessage
	{
		public const uint Id = 610;
		public override uint MessageId => Id;
		public IEnumerable<uint> objectUID { get; set; }

		public ObjectsDeletedMessage(IEnumerable<uint> objectUID)
		{
			this.objectUID = objectUID;
		}

		public ObjectsDeletedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)objectUID.Count());
			foreach (var objectToSend in objectUID)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var objectUIDCount = reader.ReadUShort();
			var objectUID_ = new uint[objectUIDCount];
			for (var objectUIDIndex = 0; objectUIDIndex < objectUIDCount; objectUIDIndex++)
			{
				objectUID_[objectUIDIndex] = reader.ReadVarUInt();
			}
			objectUID = objectUID_;
		}

	}
}
