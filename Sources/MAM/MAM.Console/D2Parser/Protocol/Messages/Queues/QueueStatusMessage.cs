namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class QueueStatusMessage : NetworkMessage
	{
		public const uint Id = 8974;
		public override uint MessageId => Id;
		public ushort position { get; set; }
		public ushort total { get; set; }

		public QueueStatusMessage(ushort position, ushort total)
		{
			this.position = position;
			this.total = total;
		}

		public QueueStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort(position);
			writer.WriteUShort(total);
		}

		public override void Deserialize(IDataReader reader)
		{
			position = reader.ReadUShort();
			total = reader.ReadUShort();
		}

	}
}
