namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceChangeGuildRightsMessage : NetworkMessage
	{
		public const uint Id = 2201;
		public override uint MessageId => Id;
		public uint guildId { get; set; }
		public sbyte rights { get; set; }

		public AllianceChangeGuildRightsMessage(uint guildId, sbyte rights)
		{
			this.guildId = guildId;
			this.rights = rights;
		}

		public AllianceChangeGuildRightsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(guildId);
			writer.WriteSByte(rights);
		}

		public override void Deserialize(IDataReader reader)
		{
			guildId = reader.ReadVarUInt();
			rights = reader.ReadSByte();
		}

	}
}
