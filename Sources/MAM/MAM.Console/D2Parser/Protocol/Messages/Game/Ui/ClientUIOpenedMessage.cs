namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ClientUIOpenedMessage : NetworkMessage
	{
		public const uint Id = 2042;
		public override uint MessageId => Id;
		public sbyte type { get; set; }

		public ClientUIOpenedMessage(sbyte type)
		{
			this.type = type;
		}

		public ClientUIOpenedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(type);
		}

		public override void Deserialize(IDataReader reader)
		{
			type = reader.ReadSByte();
		}

	}
}
