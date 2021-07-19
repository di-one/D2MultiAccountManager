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
	public class ExchangeTypesItemsExchangerDescriptionForUserMessage : NetworkMessage
	{
		public const uint Id = 6000;
		public override uint MessageId => Id;
		public int objectType { get; set; }
		public IEnumerable<BidExchangerObjectInfo> itemTypeDescriptions { get; set; }

		public ExchangeTypesItemsExchangerDescriptionForUserMessage(int objectType, IEnumerable<BidExchangerObjectInfo> itemTypeDescriptions)
		{
			this.objectType = objectType;
			this.itemTypeDescriptions = itemTypeDescriptions;
		}

		public ExchangeTypesItemsExchangerDescriptionForUserMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(objectType);
			writer.WriteShort((short)itemTypeDescriptions.Count());
			foreach (var objectToSend in itemTypeDescriptions)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			objectType = reader.ReadInt();
			var itemTypeDescriptionsCount = reader.ReadUShort();
			var itemTypeDescriptions_ = new BidExchangerObjectInfo[itemTypeDescriptionsCount];
			for (var itemTypeDescriptionsIndex = 0; itemTypeDescriptionsIndex < itemTypeDescriptionsCount; itemTypeDescriptionsIndex++)
			{
				var objectToAdd = new BidExchangerObjectInfo();
				objectToAdd.Deserialize(reader);
				itemTypeDescriptions_[itemTypeDescriptionsIndex] = objectToAdd;
			}
			itemTypeDescriptions = itemTypeDescriptions_;
		}

	}
}
