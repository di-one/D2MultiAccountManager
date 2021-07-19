namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeShopStockMovementRemovedMessage : NetworkMessage
	{
		public const uint Id = 8887;
		public override uint MessageId => Id;
		public uint objectId { get; set; }

		public ExchangeShopStockMovementRemovedMessage(uint objectId)
		{
			this.objectId = objectId;
		}

		public ExchangeShopStockMovementRemovedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectId);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUInt();
		}

	}
}
