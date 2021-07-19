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
	public class ObjectsAddedMessage : NetworkMessage
	{
		public const uint Id = 2979;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItem> @object { get; set; }

		public ObjectsAddedMessage(IEnumerable<ObjectItem> @object)
		{
			this.@object = @object;
		}

		public ObjectsAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)@object.Count());
			foreach (var objectToSend in @object)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var @objectCount = reader.ReadUShort();
			var @object_ = new ObjectItem[@objectCount];
			for (var @objectIndex = 0; @objectIndex < @objectCount; @objectIndex++)
			{
				var objectToAdd = new ObjectItem();
				objectToAdd.Deserialize(reader);
				@object_[@objectIndex] = objectToAdd;
			}
			@object = @object_;
		}

	}
}
