namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHouseGenericItemRemovedMessage : NetworkMessage
	{
		public const uint Id = 5447;
		public override uint MessageId => Id;
		public ushort objGenericId { get; set; }

		public ExchangeBidHouseGenericItemRemovedMessage(ushort objGenericId)
		{
			this.objGenericId = objGenericId;
		}

		public ExchangeBidHouseGenericItemRemovedMessage() { }

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
