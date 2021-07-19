namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildFactSheetInformations : GuildInformations
	{
		public new const short Id = 8504;
		public override short TypeId => Id;
		public ulong leaderId { get; set; }
		public ushort nbMembers { get; set; }

		public GuildFactSheetInformations(uint guildId, string guildName, byte guildLevel, GuildEmblem guildEmblem, ulong leaderId, ushort nbMembers)
		{
			this.guildId = guildId;
			this.guildName = guildName;
			this.guildLevel = guildLevel;
			this.guildEmblem = guildEmblem;
			this.leaderId = leaderId;
			this.nbMembers = nbMembers;
		}

		public GuildFactSheetInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(leaderId);
			writer.WriteVarUShort(nbMembers);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			leaderId = reader.ReadVarULong();
			nbMembers = reader.ReadVarUShort();
		}

	}
}
