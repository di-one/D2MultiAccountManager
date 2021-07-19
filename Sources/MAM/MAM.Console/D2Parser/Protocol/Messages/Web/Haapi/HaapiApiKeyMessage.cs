namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HaapiApiKeyMessage : NetworkMessage
	{
		public const uint Id = 9615;
		public override uint MessageId => Id;
		public string token { get; set; }

		public HaapiApiKeyMessage(string token)
		{
			this.token = token;
		}

		public HaapiApiKeyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(token);
		}

		public override void Deserialize(IDataReader reader)
		{
			token = reader.ReadUTF();
		}

	}
}
