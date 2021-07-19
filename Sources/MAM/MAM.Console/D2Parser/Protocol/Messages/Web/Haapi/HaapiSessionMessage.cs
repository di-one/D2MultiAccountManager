namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HaapiSessionMessage : NetworkMessage
	{
		public const uint Id = 3824;
		public override uint MessageId => Id;
		public string key { get; set; }
		public sbyte type { get; set; }

		public HaapiSessionMessage(string key, sbyte type)
		{
			this.key = key;
			this.type = type;
		}

		public HaapiSessionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(key);
			writer.WriteSByte(type);
		}

		public override void Deserialize(IDataReader reader)
		{
			key = reader.ReadUTF();
			type = reader.ReadSByte();
		}

	}
}
