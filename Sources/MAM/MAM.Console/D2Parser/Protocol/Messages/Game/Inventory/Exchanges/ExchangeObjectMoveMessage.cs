namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeObjectMoveMessage : NetworkMessage
	{
		public const uint Id = 5362;
		public override uint MessageId => Id;
		public uint objectUID { get; set; }
		public int quantity { get; set; }

		public ExchangeObjectMoveMessage(uint objectUID, int quantity)
		{
			this.objectUID = objectUID;
			this.quantity = quantity;
		}

		public ExchangeObjectMoveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectUID);
			writer.WriteVarInt(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectUID = reader.ReadVarUInt();
			quantity = reader.ReadVarInt();
		}

	}
}
