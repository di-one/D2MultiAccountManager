namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SequenceStartMessage : NetworkMessage
	{
		public const uint Id = 2177;
		public override uint MessageId => Id;
		public sbyte sequenceType { get; set; }
		public double authorId { get; set; }

		public SequenceStartMessage(sbyte sequenceType, double authorId)
		{
			this.sequenceType = sequenceType;
			this.authorId = authorId;
		}

		public SequenceStartMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(sequenceType);
			writer.WriteDouble(authorId);
		}

		public override void Deserialize(IDataReader reader)
		{
			sequenceType = reader.ReadSByte();
			authorId = reader.ReadDouble();
		}

	}
}
