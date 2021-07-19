namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInAllianceInformations : GuildInformations
	{
		public new const short Id = 3579;
		public override short TypeId => Id;
		public byte nbMembers { get; set; }
		public int joinDate { get; set; }

		public GuildInAllianceInformations(uint guildId, string guildName, byte guildLevel, GuildEmblem guildEmblem, byte nbMembers, int joinDate)
		{
			this.guildId = guildId;
			this.guildName = guildName;
			this.guildLevel = guildLevel;
			this.guildEmblem = guildEmblem;
			this.nbMembers = nbMembers;
			this.joinDate = joinDate;
		}

		public GuildInAllianceInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteByte(nbMembers);
			writer.WriteInt(joinDate);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			nbMembers = reader.ReadByte();
			joinDate = reader.ReadInt();
		}

	}
}
