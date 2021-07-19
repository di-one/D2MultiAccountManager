namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectDeleteMessage : NetworkMessage
	{
		public const uint Id = 9552;
		public override uint MessageId => Id;
		public uint objectUID { get; set; }
		public uint quantity { get; set; }

		public ObjectDeleteMessage(uint objectUID, uint quantity)
		{
			this.objectUID = objectUID;
			this.quantity = quantity;
		}

		public ObjectDeleteMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectUID);
			writer.WriteVarUInt(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectUID = reader.ReadVarUInt();
			quantity = reader.ReadVarUInt();
		}

	}
}
