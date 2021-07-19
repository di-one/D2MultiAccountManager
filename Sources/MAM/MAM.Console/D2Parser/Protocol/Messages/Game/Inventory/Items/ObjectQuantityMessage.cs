namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectQuantityMessage : NetworkMessage
	{
		public const uint Id = 9204;
		public override uint MessageId => Id;
		public uint objectUID { get; set; }
		public uint quantity { get; set; }
		public sbyte origin { get; set; }

		public ObjectQuantityMessage(uint objectUID, uint quantity, sbyte origin)
		{
			this.objectUID = objectUID;
			this.quantity = quantity;
			this.origin = origin;
		}

		public ObjectQuantityMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectUID);
			writer.WriteVarUInt(quantity);
			writer.WriteSByte(origin);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectUID = reader.ReadVarUInt();
			quantity = reader.ReadVarUInt();
			origin = reader.ReadSByte();
		}

	}
}
