namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildGetInformationsMessage : NetworkMessage
	{
		public const uint Id = 5467;
		public override uint MessageId => Id;
		public sbyte infoType { get; set; }

		public GuildGetInformationsMessage(sbyte infoType)
		{
			this.infoType = infoType;
		}

		public GuildGetInformationsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(infoType);
		}

		public override void Deserialize(IDataReader reader)
		{
			infoType = reader.ReadSByte();
		}

	}
}
