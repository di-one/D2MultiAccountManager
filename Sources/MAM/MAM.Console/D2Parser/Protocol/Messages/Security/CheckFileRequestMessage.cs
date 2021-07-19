namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CheckFileRequestMessage : NetworkMessage
	{
		public const uint Id = 7250;
		public override uint MessageId => Id;
		public string filename { get; set; }
		public sbyte type { get; set; }

		public CheckFileRequestMessage(string filename, sbyte type)
		{
			this.filename = filename;
			this.type = type;
		}

		public CheckFileRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(filename);
			writer.WriteSByte(type);
		}

		public override void Deserialize(IDataReader reader)
		{
			filename = reader.ReadUTF();
			type = reader.ReadSByte();
		}

	}
}
