namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildVersatileInformations
	{
		public const short Id  = 9761;
		public virtual short TypeId => Id;
		public uint guildId { get; set; }
		public ulong leaderId { get; set; }
		public byte guildLevel { get; set; }
		public byte nbMembers { get; set; }

		public GuildVersatileInformations(uint guildId, ulong leaderId, byte guildLevel, byte nbMembers)
		{
			this.guildId = guildId;
			this.leaderId = leaderId;
			this.guildLevel = guildLevel;
			this.nbMembers = nbMembers;
		}

		public GuildVersatileInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(guildId);
			writer.WriteVarULong(leaderId);
			writer.WriteByte(guildLevel);
			writer.WriteByte(nbMembers);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			guildId = reader.ReadVarUInt();
			leaderId = reader.ReadVarULong();
			guildLevel = reader.ReadByte();
			nbMembers = reader.ReadByte();
		}

	}
}
