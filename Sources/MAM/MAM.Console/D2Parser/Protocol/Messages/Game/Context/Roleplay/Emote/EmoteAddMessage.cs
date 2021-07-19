namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class EmoteAddMessage : NetworkMessage
	{
		public const uint Id = 6710;
		public override uint MessageId => Id;
		public byte emoteId { get; set; }

		public EmoteAddMessage(byte emoteId)
		{
			this.emoteId = emoteId;
		}

		public EmoteAddMessage() { }

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
