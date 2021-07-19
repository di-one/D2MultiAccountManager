namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class EmotePlayRequestMessage : NetworkMessage
	{
		public const uint Id = 6993;
		public override uint MessageId => Id;
		public byte emoteId { get; set; }

		public EmotePlayRequestMessage(byte emoteId)
		{
			this.emoteId = emoteId;
		}

		public EmotePlayRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteByte(emoteId);
		}

		public override void Deserialize(IDataReader reader)
		{
			emoteId = reader.ReadByte();
		}

	}
}
