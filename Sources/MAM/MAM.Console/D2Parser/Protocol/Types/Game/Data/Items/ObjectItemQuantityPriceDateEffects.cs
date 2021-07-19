namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectItemQuantityPriceDateEffects : ObjectItemGenericQuantity
	{
		public new const short Id = 1382;
		public override short TypeId => Id;
		public ulong price { get; set; }
		public ObjectEffects effects { get; set; }
		public int date { get; set; }

		public ObjectItemQuantityPriceDateEffects(ushort objectGID, uint quantity, ulong price, ObjectEffects effects, int date)
		{
			this.objectGID = objectGID;
			this.quantity = quantity;
			this.price = price;
			this.effects = effects;
			this.date = date;
		}

		public ObjectItemQuantityPriceDateEffects() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(price);
			effects.Serialize(writer);
			writer.WriteInt(date);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			price = reader.ReadVarULong();
			effects = new ObjectEffects();
			effects.Deserialize(reader);
			date = reader.ReadInt();
		}

	}
}
