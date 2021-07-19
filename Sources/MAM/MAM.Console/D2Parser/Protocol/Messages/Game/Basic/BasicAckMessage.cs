namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicAckMessage : NetworkMessage
	{
		public const uint Id = 3130;
		public override uint MessageId => Id;
		public uint seq { get; set; }
		public ushort lastPacketId { get; set; }

		public BasicAckMessage(uint seq, ushort lastPacketId)
		{
			this.seq = seq;
			this.lastPacketId = lastPacketId;
		}

		public BasicAckMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(seq);
			writer.WriteVarUShort(lastPacketId);
		}

		public override void Deserialize(IDataReader reader)
		{
			seq = reader.ReadVarUInt();
			lastPacketId = reader.ReadVarUShort();
		}

	}
}
