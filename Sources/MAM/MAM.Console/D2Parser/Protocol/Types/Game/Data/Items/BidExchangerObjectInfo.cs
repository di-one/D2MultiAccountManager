namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BidExchangerObjectInfo
	{
		public const short Id  = 8892;
		public virtual short TypeId => Id;
		public uint objectUID { get; set; }
		public ushort objectGID { get; set; }
		public int objectType { get; set; }
		public IEnumerable<ObjectEffect> effects { get; set; }
		public IEnumerable<ulong> prices { get; set; }

		public BidExchangerObjectInfo(uint objectUID, ushort objectGID, int objectType, IEnumerable<ObjectEffect> effects, IEnumerable<ulong> prices)
		{
			this.objectUID = objectUID;
			this.objectGID = objectGID;
			this.objectType = objectType;
			this.effects = effects;
			this.prices = prices;
		}

		public BidExchangerObjectInfo() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectUID);
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

		public virtual void Deserialize(IDataReader reader)
		{
			objectUID = reader.ReadVarUInt();
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
