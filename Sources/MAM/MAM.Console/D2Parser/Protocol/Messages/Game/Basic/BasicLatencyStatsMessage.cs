namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicLatencyStatsMessage : NetworkMessage
	{
		public const uint Id = 8738;
		public override uint MessageId => Id;
		public ushort latency { get; set; }
		public ushort sampleCount { get; set; }
		public ushort max { get; set; }

		public BasicLatencyStatsMessage(ushort latency, ushort sampleCount, ushort max)
		{
			this.latency = latency;
			this.sampleCount = sampleCount;
			this.max = max;
		}

		public BasicLatencyStatsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort(latency);
			writer.WriteVarUShort(sampleCount);
			writer.WriteVarUShort(max);
		}

		public override void Deserialize(IDataReader reader)
		{
			latency = reader.ReadUShort();
			sampleCount = reader.ReadVarUShort();
			max = reader.ReadVarUShort();
		}

	}
}
