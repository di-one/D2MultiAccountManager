namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildFactsErrorMessage : NetworkMessage
	{
		public const uint Id = 3732;
		public override uint MessageId => Id;
		public uint guildId { get; set; }

		public GuildFactsErrorMessage(uint guildId)
		{
			this.guildId = guildId;
		}

		public GuildFactsErrorMessage() { }

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
