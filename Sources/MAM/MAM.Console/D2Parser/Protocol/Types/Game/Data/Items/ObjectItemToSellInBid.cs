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
	public class ObjectItemToSellInBid : ObjectItemToSell
	{
		public new const short Id = 4507;
		public override short TypeId => Id;
		public int unsoldDelay { get; set; }

		public ObjectItemToSellInBid(ushort objectGID, IEnumerable<ObjectEffect> effects, uint objectUID, uint quantity, ulong objectPrice, int unsoldDelay)
		{
			this.objectGID = objectGID;
			this.effects = effects;
			this.objectUID = objectUID;
			this.quantity = quantity;
			this.objectPrice = objectPrice;
			this.unsoldDelay = unsoldDelay;
		}

		public ObjectItemToSellInBid() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(unsoldDelay);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			unsoldDelay = reader.ReadInt();
		}

	}
}
