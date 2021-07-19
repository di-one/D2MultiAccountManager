namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInAllianceVersatileInformations : GuildVersatileInformations
	{
		public new const short Id = 2686;
		public override short TypeId => Id;
		public uint allianceId { get; set; }

		public GuildInAllianceVersatileInformations(uint guildId, ulong leaderId, byte guildLevel, byte nbMembers, uint allianceId)
		{
			this.guildId = guildId;
			this.leaderId = leaderId;
			this.guildLevel = guildLevel;
			this.nbMembers = nbMembers;
			this.allianceId = allianceId;
		}

		public GuildInAllianceVersatileInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(allianceId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			allianceId = reader.ReadVarUInt();
		}

	}
}
