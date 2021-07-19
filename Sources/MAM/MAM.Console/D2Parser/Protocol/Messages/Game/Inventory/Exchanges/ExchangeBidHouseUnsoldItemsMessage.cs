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
	public class ExchangeBidHouseUnsoldItemsMessage : NetworkMessage
	{
		public const uint Id = 8959;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItemGenericQuantity> items { get; set; }

		public ExchangeBidHouseUnsoldItemsMessage(IEnumerable<ObjectItemGenericQuantity> items)
		{
			this.items = items;
		}

		public ExchangeBidHouseUnsoldItemsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)items.Count());
			foreach (var objectToSend in items)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var itemsCount = reader.ReadUShort();
			var items_ = new ObjectItemGenericQuantity[itemsCount];
			for (var itemsIndex = 0; itemsIndex < itemsCount; itemsIndex++)
			{
				var objectToAdd = new ObjectItemGenericQuantity();
				objectToAdd.Deserialize(reader);
				items_[itemsIndex] = objectToAdd;
			}
			items = items_;
		}

	}
}
