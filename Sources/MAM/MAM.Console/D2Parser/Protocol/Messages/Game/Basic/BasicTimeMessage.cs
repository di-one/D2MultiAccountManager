namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicTimeMessage : NetworkMessage
	{
		public const uint Id = 4907;
		public override uint MessageId => Id;
		public double timestamp { get; set; }
		public short timezoneOffset { get; set; }

		public BasicTimeMessage(double timestamp, short timezoneOffset)
		{
			this.timestamp = timestamp;
			this.timezoneOffset = timezoneOffset;
		}

		public BasicTimeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(timestamp);
			writer.WriteShort(timezoneOffset);
		}

		public override void Deserialize(IDataReader reader)
		{
			timestamp = reader.ReadDouble();
			timezoneOffset = reader.ReadShort();
		}

	}
}
