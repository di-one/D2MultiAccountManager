namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHouseGenericItemAddedMessage : NetworkMessage
	{
		public const uint Id = 5133;
		public override uint MessageId => Id;
		public ushort objGenericId { get; set; }

		public ExchangeBidHouseGenericItemAddedMessage(ushort objGenericId)
		{
			this.objGenericId = objGenericId;
		}

		public ExchangeBidHouseGenericItemAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objGenericId);
		}

		public override void Deserialize(IDataReader reader)
		{
			objGenericId = reader.ReadVarUShort();
		}

	}
}
