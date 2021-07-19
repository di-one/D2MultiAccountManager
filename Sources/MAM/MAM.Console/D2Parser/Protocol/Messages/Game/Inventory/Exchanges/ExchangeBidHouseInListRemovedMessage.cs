namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHouseInListRemovedMessage : NetworkMessage
	{
		public const uint Id = 898;
		public override uint MessageId => Id;
		public int itemUID { get; set; }
		public ushort objectGID { get; set; }
		public int objectType { get; set; }

		public ExchangeBidHouseInListRemovedMessage(int itemUID, ushort objectGID, int objectType)
		{
			this.itemUID = itemUID;
			this.objectGID = objectGID;
			this.objectType = objectType;
		}

		public ExchangeBidHouseInListRemovedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(itemUID);
			writer.WriteVarUShort(objectGID);
			writer.WriteInt(objectType);
		}

		public override void Deserialize(IDataReader reader)
		{
			itemUID = reader.ReadInt();
			objectGID = reader.ReadVarUShort();
			objectType = reader.ReadInt();
		}

	}
}
