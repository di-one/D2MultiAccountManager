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
	public class EvolutiveObjectRecycleResultMessage : NetworkMessage
	{
		public const uint Id = 4691;
		public override uint MessageId => Id;
		public IEnumerable<RecycledItem> recycledItems { get; set; }

		public EvolutiveObjectRecycleResultMessage(IEnumerable<RecycledItem> recycledItems)
		{
			this.recycledItems = recycledItems;
		}

		public EvolutiveObjectRecycleResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)recycledItems.Count());
			foreach (var objectToSend in recycledItems)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var recycledItemsCount = reader.ReadUShort();
			var recycledItems_ = new RecycledItem[recycledItemsCount];
			for (var recycledItemsIndex = 0; recycledItemsIndex < recycledItemsCount; recycledItemsIndex++)
			{
				var objectToAdd = new RecycledItem();
				objectToAdd.Deserialize(reader);
				recycledItems_[recycledItemsIndex] = objectToAdd;
			}
			recycledItems = recycledItems_;
		}

	}
}
