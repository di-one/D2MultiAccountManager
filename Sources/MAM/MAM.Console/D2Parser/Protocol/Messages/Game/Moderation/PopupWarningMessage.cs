namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PopupWarningMessage : NetworkMessage
	{
		public const uint Id = 1148;
		public override uint MessageId => Id;
		public byte lockDuration { get; set; }
		public string author { get; set; }
		public string content { get; set; }

		public PopupWarningMessage(byte lockDuration, string author, string content)
		{
			this.lockDuration = lockDuration;
			this.author = author;
			this.content = content;
		}

		public PopupWarningMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteByte(lockDuration);
			writer.WriteUTF(author);
			writer.WriteUTF(content);
		}

		public override void Deserialize(IDataReader reader)
		{
			lockDuration = reader.ReadByte();
			author = reader.ReadUTF();
			content = reader.ReadUTF();
		}

	}
}
