namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class EmotePlayAbstractMessage : NetworkMessage
	{
		public const uint Id = 8273;
		public override uint MessageId => Id;
		public byte emoteId { get; set; }
		public double emoteStartTime { get; set; }

		public EmotePlayAbstractMessage(byte emoteId, double emoteStartTime)
		{
			this.emoteId = emoteId;
			this.emoteStartTime = emoteStartTime;
		}

		public EmotePlayAbstractMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteByte(emoteId);
			writer.WriteDouble(emoteStartTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			emoteId = reader.ReadByte();
			emoteStartTime = reader.ReadDouble();
		}

	}
}
