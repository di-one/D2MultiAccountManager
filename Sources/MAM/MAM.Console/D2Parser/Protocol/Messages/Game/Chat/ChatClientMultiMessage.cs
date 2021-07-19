namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatClientMultiMessage : ChatAbstractClientMessage
	{
		public new const uint Id = 107;
		public override uint MessageId => Id;
		public sbyte channel { get; set; }

		public ChatClientMultiMessage(string content, sbyte channel)
		{
			this.content = content;
			this.channel = channel;
		}

		public ChatClientMultiMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(channel);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			channel = reader.ReadSByte();
		}

	}
}
