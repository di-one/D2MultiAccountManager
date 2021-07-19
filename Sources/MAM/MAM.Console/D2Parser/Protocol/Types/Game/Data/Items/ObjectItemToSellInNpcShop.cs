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
	public class ObjectItemToSellInNpcShop : ObjectItemMinimalInformation
	{
		public new const short Id = 3020;
		public override short TypeId => Id;
		public ulong objectPrice { get; set; }
		public string buyCriterion { get; set; }

		public ObjectItemToSellInNpcShop(ushort objectGID, IEnumerable<ObjectEffect> effects, ulong objectPrice, string buyCriterion)
		{
			this.objectGID = objectGID;
			this.effects = effects;
			this.objectPrice = objectPrice;
			this.buyCriterion = buyCriterion;
		}

		public ObjectItemToSellInNpcShop() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(objectPrice);
			writer.WriteUTF(buyCriterion);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectPrice = reader.ReadVarULong();
			buyCriterion = reader.ReadUTF();
		}

	}
}
