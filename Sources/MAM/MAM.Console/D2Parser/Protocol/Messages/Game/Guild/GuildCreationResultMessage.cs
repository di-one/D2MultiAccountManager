namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildCreationResultMessage : NetworkMessage
	{
		public const uint Id = 4519;
		public override uint MessageId => Id;
		public sbyte result { get; set; }

		public GuildCreationResultMessage(sbyte result)
		{
			this.result = result;
		}

		public GuildCreationResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(result);
		}

		public override void Deserialize(IDataReader reader)
		{
			result = reader.ReadSByte();
		}

	}
}
