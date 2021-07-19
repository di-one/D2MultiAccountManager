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
	public class ObjectItemToSell : Item
	{
		public new const short Id = 7013;
		public override short TypeId => Id;
		public ushort objectGID { get; set; }
		public IEnumerable<ObjectEffect> effects { get; set; }
		public uint objectUID { get; set; }
		public uint quantity { get; set; }
		public ulong objectPrice { get; set; }

		public ObjectItemToSell(ushort objectGID, IEnumerable<ObjectEffect> effects, uint objectUID, uint quantity, ulong objectPrice)
		{
			this.objectGID = objectGID;
			this.effects = effects;
			this.objectUID = objectUID;
			this.quantity = quantity;
			this.objectPrice = objectPrice;
		}

		public ObjectItemToSell() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(objectGID);
			writer.WriteShort((short)effects.Count());
			foreach (var objectToSend in effects)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteVarUInt(objectUID);
			writer.WriteVarUInt(quantity);
			writer.WriteVarULong(objectPrice);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectGID = reader.ReadVarUShort();
			var effectsCount = reader.ReadUShort();
			var effects_ = new ObjectEffect[effectsCount];
			for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				effects_[effectsIndex] = objectToAdd;
			}
			effects = effects_;
			objectUID = reader.ReadVarUInt();
			quantity = reader.ReadVarUInt();
			objectPrice = reader.ReadVarULong();
		}

	}
}
