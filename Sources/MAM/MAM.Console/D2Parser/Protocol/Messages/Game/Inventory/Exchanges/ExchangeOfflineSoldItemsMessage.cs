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
	public class ExchangeOfflineSoldItemsMessage : NetworkMessage
	{
		public const uint Id = 1554;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItemQuantityPriceDateEffects> bidHouseItems { get; set; }
		public IEnumerable<ObjectItemQuantityPriceDateEffects> merchantItems { get; set; }

		public ExchangeOfflineSoldItemsMessage(IEnumerable<ObjectItemQuantityPriceDateEffects> bidHouseItems, IEnumerable<ObjectItemQuantityPriceDateEffects> merchantItems)
		{
			this.bidHouseItems = bidHouseItems;
			this.merchantItems = merchantItems;
		}

		public ExchangeOfflineSoldItemsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)bidHouseItems.Count());
			foreach (var objectToSend in bidHouseItems)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)merchantItems.Count());
			foreach (var objectToSend in merchantItems)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var bidHouseItemsCount = reader.ReadUShort();
			var bidHouseItems_ = new ObjectItemQuantityPriceDateEffects[bidHouseItemsCount];
			for (var bidHouseItemsIndex = 0; bidHouseItemsIndex < bidHouseItemsCount; bidHouseItemsIndex++)
			{
				var objectToAdd = new ObjectItemQuantityPriceDateEffects();
				objectToAdd.Deserialize(reader);
				bidHouseItems_[bidHouseItemsIndex] = objectToAdd;
			}
			bidHouseItems = bidHouseItems_;
			var merchantItemsCount = reader.ReadUShort();
			var merchantItems_ = new ObjectItemQuantityPriceDateEffects[merchantItemsCount];
			for (var merchantItemsIndex = 0; merchantItemsIndex < merchantItemsCount; merchantItemsIndex++)
			{
				var objectToAdd = new ObjectItemQuantityPriceDateEffects();
				objectToAdd.Deserialize(reader);
				merchantItems_[merchantItemsIndex] = objectToAdd;
			}
			merchantItems = merchantItems_;
		}

	}
}
