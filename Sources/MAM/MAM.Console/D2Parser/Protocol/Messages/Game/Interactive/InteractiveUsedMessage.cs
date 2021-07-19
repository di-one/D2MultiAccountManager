namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InteractiveUsedMessage : NetworkMessage
	{
		public const uint Id = 9664;
		public override uint MessageId => Id;
		public ulong entityId { get; set; }
		public uint elemId { get; set; }
		public ushort skillId { get; set; }
		public ushort duration { get; set; }
		public bool canMove { get; set; }

		public InteractiveUsedMessage(ulong entityId, uint elemId, ushort skillId, ushort duration, bool canMove)
		{
			this.entityId = entityId;
			this.elemId = elemId;
			this.skillId = skillId;
			this.duration = duration;
			this.canMove = canMove;
		}

		public InteractiveUsedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(entityId);
			writer.WriteVarUInt(elemId);
			writer.WriteVarUShort(skillId);
			writer.WriteVarUShort(duration);
			writer.WriteBoolean(canMove);
		}

		public override void Deserialize(IDataReader reader)
		{
			entityId = reader.ReadVarULong();
			elemId = reader.ReadVarUInt();
			skillId = reader.ReadVarUShort();
			duration = reader.ReadVarUShort();
			canMove = reader.ReadBoolean();
		}

	}
}
