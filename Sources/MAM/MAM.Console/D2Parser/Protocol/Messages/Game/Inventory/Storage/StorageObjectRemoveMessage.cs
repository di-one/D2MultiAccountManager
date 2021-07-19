namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StorageObjectRemoveMessage : NetworkMessage
	{
		public const uint Id = 8680;
		public override uint MessageId => Id;
		public uint objectUID { get; set; }

		public StorageObjectRemoveMessage(uint objectUID)
		{
			this.objectUID = objectUID;
		}

		public StorageObjectRemoveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectUID);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectUID = reader.ReadVarUInt();
		}

	}
}
