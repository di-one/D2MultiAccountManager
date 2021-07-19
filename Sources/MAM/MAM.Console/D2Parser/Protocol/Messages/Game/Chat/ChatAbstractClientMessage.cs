namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatAbstractClientMessage : NetworkMessage
	{
		public const uint Id = 4914;
		public override uint MessageId => Id;
		public string content { get; set; }

		public ChatAbstractClientMessage(string content)
		{
			this.content = content;
		}

		public ChatAbstractClientMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(content);
		}

		public override void Deserialize(IDataReader reader)
		{
			content = reader.ReadUTF();
		}

	}
}
