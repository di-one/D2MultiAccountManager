namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectDeletedMessage : NetworkMessage
	{
		public const uint Id = 793;
		public override uint MessageId => Id;
		public uint objectUID { get; set; }

		public ObjectDeletedMessage(uint objectUID)
		{
			this.objectUID = objectUID;
		}

		public ObjectDeletedMessage() { }

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
