namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismsListRegisterMessage : NetworkMessage
	{
		public const uint Id = 4752;
		public override uint MessageId => Id;
		public sbyte listen { get; set; }

		public PrismsListRegisterMessage(sbyte listen)
		{
			this.listen = listen;
		}

		public PrismsListRegisterMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(listen);
		}

		public override void Deserialize(IDataReader reader)
		{
			listen = reader.ReadSByte();
		}

	}
}
