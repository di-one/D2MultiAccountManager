namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectGroundAddedMessage : NetworkMessage
	{
		public const uint Id = 9392;
		public override uint MessageId => Id;
		public ushort cellId { get; set; }
		public ushort objectGID { get; set; }

		public ObjectGroundAddedMessage(ushort cellId, ushort objectGID)
		{
			this.cellId = cellId;
			this.objectGID = objectGID;
		}

		public ObjectGroundAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(cellId);
			writer.WriteVarUShort(objectGID);
		}

		public override void Deserialize(IDataReader reader)
		{
			cellId = reader.ReadVarUShort();
			objectGID = reader.ReadVarUShort();
		}

	}
}
