namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectMovementMessage : NetworkMessage
	{
		public const uint Id = 3776;
		public override uint MessageId => Id;
		public uint objectUID { get; set; }
		public short position { get; set; }

		public ObjectMovementMessage(uint objectUID, short position)
		{
			this.objectUID = objectUID;
			this.position = position;
		}

		public ObjectMovementMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectUID);
			writer.WriteShort(position);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectUID = reader.ReadVarUInt();
			position = reader.ReadShort();
		}

	}
}
