namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HaapiShopApiKeyMessage : NetworkMessage
	{
		public const uint Id = 2356;
		public override uint MessageId => Id;
		public string token { get; set; }

		public HaapiShopApiKeyMessage(string token)
		{
			this.token = token;
		}

		public HaapiShopApiKeyMessage() { }

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
