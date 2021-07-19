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
	public class EntitiesInformationMessage : NetworkMessage
	{
		public const uint Id = 45;
		public override uint MessageId => Id;
		public IEnumerable<EntityInformation> entities { get; set; }

		public EntitiesInformationMessage(IEnumerable<EntityInformation> entities)
		{
			this.entities = entities;
		}

		public EntitiesInformationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)entities.Count());
			foreach (var objectToSend in entities)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var entitiesCount = reader.ReadUShort();
			var entities_ = new EntityInformation[entitiesCount];
			for (var entitiesIndex = 0; entitiesIndex < entitiesCount; entitiesIndex++)
			{
				var objectToAdd = new EntityInformation();
				objectToAdd.Deserialize(reader);
				entities_[entitiesIndex] = objectToAdd;
			}
			entities = entities_;
		}

	}
}
