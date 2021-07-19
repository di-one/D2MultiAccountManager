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
	public class ExchangeBidHouseInListAddedMessage : NetworkMessage
	{
		public const uint Id = 2783;
		public override uint MessageId => Id;
		public int itemUID { get; set; }
		public ushort objectGID { get; set; }
		public int objectType { get; set; }
		public IEnumerable<ObjectEffect> effects { get; set; }
		public IEnumerable<ulong> prices { get; set; }

		public ExchangeBidHouseInListAddedMessage(int itemUID, ushort objectGID, int objectType, IEnumerable<ObjectEffect> effects, IEnumerable<ulong> prices)
		{
			this.itemUID = itemUID;
			this.objectGID = objectGID;
			this.objectType = objectType;
			this.effects = effects;
			this.prices = prices;
		}

		public ExchangeBidHouseInListAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(itemUID);
			writer.WriteVarUShort(objectGID);
			writer.WriteInt(objectType);
			writer.WriteShort((short)effects.Count());
			foreach (var objectToSend in effects)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)prices.Count());
			foreach (var objectToSend in prices)
            {
				writer.WriteVarULong(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			itemUID = reader.ReadInt();
			objectGID = reader.ReadVarUShort();
			objectType = reader.ReadInt();
			var effectsCount = reader.ReadUShort();
			var effects_ = new ObjectEffect[effectsCount];
			for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				effects_[effectsIndex] = objectToAdd;
			}
			effects = effects_;
			var pricesCount = reader.ReadUShort();
			var prices_ = new ulong[pricesCount];
			for (var pricesIndex = 0; pricesIndex < pricesCount; pricesIndex++)
			{
				prices_[pricesIndex] = reader.ReadVarULong();
			}
			prices = prices_;
		}

	}
}
