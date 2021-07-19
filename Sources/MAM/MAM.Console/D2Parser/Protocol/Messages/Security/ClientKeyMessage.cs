namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ClientKeyMessage : NetworkMessage
	{
		public const uint Id = 982;
		public override uint MessageId => Id;
		public string key { get; set; }

		public ClientKeyMessage(string key)
		{
			this.key = key;
		}

		public ClientKeyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(key);
		}

		public override void Deserialize(IDataReader reader)
		{
			key = reader.ReadUTF();
		}

	}
}
