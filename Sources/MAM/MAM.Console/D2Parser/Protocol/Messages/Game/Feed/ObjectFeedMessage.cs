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
	public class ObjectFeedMessage : NetworkMessage
	{
		public const uint Id = 2666;
		public override uint MessageId => Id;
		public uint objectUID { get; set; }
		public IEnumerable<ObjectItemQuantity> meal { get; set; }

		public ObjectFeedMessage(uint objectUID, IEnumerable<ObjectItemQuantity> meal)
		{
			this.objectUID = objectUID;
			this.meal = meal;
		}

		public ObjectFeedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectUID);
			writer.WriteShort((short)meal.Count());
			foreach (var objectToSend in meal)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			objectUID = reader.ReadVarUInt();
			var mealCount = reader.ReadUShort();
			var meal_ = new ObjectItemQuantity[mealCount];
			for (var mealIndex = 0; mealIndex < mealCount; mealIndex++)
			{
				var objectToAdd = new ObjectItemQuantity();
				objectToAdd.Deserialize(reader);
				meal_[mealIndex] = objectToAdd;
			}
			meal = meal_;
		}

	}
}
