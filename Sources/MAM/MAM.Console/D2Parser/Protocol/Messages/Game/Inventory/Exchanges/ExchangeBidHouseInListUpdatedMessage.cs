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
	public class ExchangeBidHouseInListUpdatedMessage : ExchangeBidHouseInListAddedMessage
	{
		public new const uint Id = 4751;
		public override uint MessageId => Id;

		public ExchangeBidHouseInListUpdatedMessage(int itemUID, ushort objectGID, int objectType, IEnumerable<ObjectEffect> effects, IEnumerable<ulong> prices)
		{
			this.itemUID = itemUID;
			this.objectGID = objectGID;
			this.objectType = objectType;
			this.effects = effects;
			this.prices = prices;
		}

		public ExchangeBidHouseInListUpdatedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
