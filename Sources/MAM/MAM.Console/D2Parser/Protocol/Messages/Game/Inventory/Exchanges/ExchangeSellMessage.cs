namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeSellMessage : NetworkMessage
	{
		public const uint Id = 7844;
		public override uint MessageId => Id;
		public uint objectToSellId { get; set; }
		public uint quantity { get; set; }

		public ExchangeSellMessage(uint objectToSellId, uint quantity)
		{
			this.objectToSellId = objectToSellId;
			this.quantity = quantity;
		}

		public ExchangeSellMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectToSellId);
			writer.WriteVarUInt(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectToSellId = reader.ReadVarUInt();
			quantity = reader.ReadVarUInt();
		}

	}
}
