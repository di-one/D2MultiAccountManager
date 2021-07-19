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
	public class ObjectsQuantityMessage : NetworkMessage
	{
		public const uint Id = 5816;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItemQuantity> objectsUIDAndQty { get; set; }

		public ObjectsQuantityMessage(IEnumerable<ObjectItemQuantity> objectsUIDAndQty)
		{
			this.objectsUIDAndQty = objectsUIDAndQty;
		}

		public ObjectsQuantityMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)objectsUIDAndQty.Count());
			foreach (var objectToSend in objectsUIDAndQty)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var objectsUIDAndQtyCount = reader.ReadUShort();
			var objectsUIDAndQty_ = new ObjectItemQuantity[objectsUIDAndQtyCount];
			for (var objectsUIDAndQtyIndex = 0; objectsUIDAndQtyIndex < objectsUIDAndQtyCount; objectsUIDAndQtyIndex++)
			{
				var objectToAdd = new ObjectItemQuantity();
				objectToAdd.Deserialize(reader);
				objectsUIDAndQty_[objectsUIDAndQtyIndex] = objectToAdd;
			}
			objectsUIDAndQty = objectsUIDAndQty_;
		}

	}
}
