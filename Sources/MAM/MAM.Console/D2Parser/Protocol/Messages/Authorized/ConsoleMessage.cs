namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ConsoleMessage : NetworkMessage
	{
		public const uint Id = 5874;
		public override uint MessageId => Id;
		public sbyte type { get; set; }
		public string content { get; set; }

		public ConsoleMessage(sbyte type, string content)
		{
			this.type = type;
			this.content = content;
		}

		public ConsoleMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(type);
			writer.WriteUTF(content);
		}

		public override void Deserialize(IDataReader reader)
		{
			type = reader.ReadSByte();
			content = reader.ReadUTF();
		}

	}
}
