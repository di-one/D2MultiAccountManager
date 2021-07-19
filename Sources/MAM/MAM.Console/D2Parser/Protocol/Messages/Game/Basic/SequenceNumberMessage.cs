namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SequenceNumberMessage : NetworkMessage
	{
		public const uint Id = 513;
		public override uint MessageId => Id;
		public ushort number { get; set; }

		public SequenceNumberMessage(ushort number)
		{
			this.number = number;
		}

		public SequenceNumberMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort(number);
		}

		public override void Deserialize(IDataReader reader)
		{
			number = reader.ReadUShort();
		}

	}
}
