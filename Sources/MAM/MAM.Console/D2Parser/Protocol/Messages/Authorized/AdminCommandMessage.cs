namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AdminCommandMessage : NetworkMessage
	{
		public const uint Id = 2679;
		public override uint MessageId => Id;
		public string content { get; set; }

		public AdminCommandMessage(string content)
		{
			this.content = content;
		}

		public AdminCommandMessage() { }

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
