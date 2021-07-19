namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInsiderFactSheetInformations : GuildFactSheetInformations
	{
		public new const short Id = 473;
		public override short TypeId => Id;
		public string leaderName { get; set; }
		public ushort nbConnectedMembers { get; set; }
		public sbyte nbTaxCollectors { get; set; }
		public int lastActivity { get; set; }

		public GuildInsiderFactSheetInformations(uint guildId, string guildName, byte guildLevel, GuildEmblem guildEmblem, ulong leaderId, ushort nbMembers, string leaderName, ushort nbConnectedMembers, sbyte nbTaxCollectors, int lastActivity)
		{
			this.guildId = guildId;
			this.guildName = guildName;
			this.guildLevel = guildLevel;
			this.guildEmblem = guildEmblem;
			this.leaderId = leaderId;
			this.nbMembers = nbMembers;
			this.leaderName = leaderName;
			this.nbConnectedMembers = nbConnectedMembers;
			this.nbTaxCollectors = nbTaxCollectors;
			this.lastActivity = lastActivity;
		}

		public GuildInsiderFactSheetInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(leaderName);
			writer.WriteVarUShort(nbConnectedMembers);
			writer.WriteSByte(nbTaxCollectors);
			writer.WriteInt(lastActivity);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			leaderName = reader.ReadUTF();
			nbConnectedMembers = reader.ReadVarUShort();
			nbTaxCollectors = reader.ReadSByte();
			lastActivity = reader.ReadInt();
		}

	}
}
