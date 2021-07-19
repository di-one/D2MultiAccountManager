namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectSetPositionMessage : NetworkMessage
	{
		public const uint Id = 62;
		public override uint MessageId => Id;
		public uint objectUID { get; set; }
		public short position { get; set; }
		public uint quantity { get; set; }

		public ObjectSetPositionMessage(uint objectUID, short position, uint quantity)
		{
			this.objectUID = objectUID;
			this.position = position;
			this.quantity = quantity;
		}

		public ObjectSetPositionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectUID);
			writer.WriteShort(position);
			writer.WriteVarUInt(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectUID = reader.ReadVarUInt();
			position = reader.ReadShort();
			quantity = reader.ReadVarUInt();
		}

	}
}
