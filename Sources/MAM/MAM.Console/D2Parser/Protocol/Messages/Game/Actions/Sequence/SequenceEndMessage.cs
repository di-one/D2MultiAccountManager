namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SequenceEndMessage : NetworkMessage
	{
		public const uint Id = 5793;
		public override uint MessageId => Id;
		public ushort actionId { get; set; }
		public double authorId { get; set; }
		public sbyte sequenceType { get; set; }

		public SequenceEndMessage(ushort actionId, double authorId, sbyte sequenceType)
		{
			this.actionId = actionId;
			this.authorId = authorId;
			this.sequenceType = sequenceType;
		}

		public SequenceEndMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(actionId);
			writer.WriteDouble(authorId);
			writer.WriteSByte(sequenceType);
		}

		public override void Deserialize(IDataReader reader)
		{
			actionId = reader.ReadVarUShort();
			authorId = reader.ReadDouble();
			sequenceType = reader.ReadSByte();
		}

	}
}
