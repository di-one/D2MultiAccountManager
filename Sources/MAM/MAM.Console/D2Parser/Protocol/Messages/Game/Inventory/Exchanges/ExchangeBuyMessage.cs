namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBuyMessage : NetworkMessage
	{
		public const uint Id = 3403;
		public override uint MessageId => Id;
		public uint objectToBuyId { get; set; }
		public uint quantity { get; set; }

		public ExchangeBuyMessage(uint objectToBuyId, uint quantity)
		{
			this.objectToBuyId = objectToBuyId;
			this.quantity = quantity;
		}

		public ExchangeBuyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectToBuyId);
			writer.WriteVarUInt(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectToBuyId = reader.ReadVarUInt();
			quantity = reader.ReadVarUInt();
		}

	}
}
