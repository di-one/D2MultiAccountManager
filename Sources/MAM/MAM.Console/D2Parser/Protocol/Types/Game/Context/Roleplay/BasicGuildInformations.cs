namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicGuildInformations : AbstractSocialGroupInfos
	{
		public new const short Id = 5973;
		public override short TypeId => Id;
		public uint guildId { get; set; }
		public string guildName { get; set; }
		public byte guildLevel { get; set; }

		public BasicGuildInformations(uint guildId, string guildName, byte guildLevel)
		{
			this.guildId = guildId;
			this.guildName = guildName;
			this.guildLevel = guildLevel;
		}

		public BasicGuildInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(guildId);
			writer.WriteUTF(guildName);
			writer.WriteByte(guildLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			guildId = reader.ReadVarUInt();
			guildName = reader.ReadUTF();
			guildLevel = reader.ReadByte();
		}

	}
}
