namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildFactsRequestMessage : NetworkMessage
	{
		public const uint Id = 8501;
		public override uint MessageId => Id;
		public uint guildId { get; set; }

		public GuildFactsRequestMessage(uint guildId)
		{
			this.guildId = guildId;
		}

		public GuildFactsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(guildId);
		}

		public override void Deserialize(IDataReader reader)
		{
			guildId = reader.ReadVarUInt();
		}

	}
}
