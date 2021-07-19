namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AnomalyStateMessage : NetworkMessage
	{
		public const uint Id = 1170;
		public override uint MessageId => Id;
		public ushort subAreaId { get; set; }
		public bool open { get; set; }
		public ulong closingTime { get; set; }

		public AnomalyStateMessage(ushort subAreaId, bool open, ulong closingTime)
		{
			this.subAreaId = subAreaId;
			this.open = open;
			this.closingTime = closingTime;
		}

		public AnomalyStateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteBoolean(open);
			writer.WriteVarULong(closingTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			open = reader.ReadBoolean();
			closingTime = reader.ReadVarULong();
		}

	}
}
