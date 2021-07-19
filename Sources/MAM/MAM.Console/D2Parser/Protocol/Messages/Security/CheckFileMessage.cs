namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CheckFileMessage : NetworkMessage
	{
		public const uint Id = 7035;
		public override uint MessageId => Id;
		public string filenameHash { get; set; }
		public sbyte type { get; set; }
		public string value { get; set; }

		public CheckFileMessage(string filenameHash, sbyte type, string value)
		{
			this.filenameHash = filenameHash;
			this.type = type;
			this.value = value;
		}

		public CheckFileMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(filenameHash);
			writer.WriteSByte(type);
			writer.WriteUTF(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			filenameHash = reader.ReadUTF();
			type = reader.ReadSByte();
			value = reader.ReadUTF();
		}

	}
}
