namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceGuildLeavingMessage : NetworkMessage
	{
		public const uint Id = 5695;
		public override uint MessageId => Id;
		public bool kicked { get; set; }
		public uint guildId { get; set; }

		public AllianceGuildLeavingMessage(bool kicked, uint guildId)
		{
			this.kicked = kicked;
			this.guildId = guildId;
		}

		public AllianceGuildLeavingMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(kicked);
			writer.WriteVarUInt(guildId);
		}

		public override void Deserialize(IDataReader reader)
		{
			kicked = reader.ReadBoolean();
			guildId = reader.ReadVarUInt();
		}

	}
}
