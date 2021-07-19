namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
	{
		public new const short Id = 7131;
		public override short TypeId => Id;
		public byte level { get; set; }
		public BasicGuildInformations guildInfo { get; set; }
		public int experienceForGuild { get; set; }

		public FightResultTaxCollectorListEntry(ushort outcome, sbyte wave, FightLoot rewards, double objectId, bool alive, byte level, BasicGuildInformations guildInfo, int experienceForGuild)
		{
			this.outcome = outcome;
			this.wave = wave;
			this.rewards = rewards;
			this.objectId = objectId;
			this.alive = alive;
			this.level = level;
			this.guildInfo = guildInfo;
			this.experienceForGuild = experienceForGuild;
		}

		public FightResultTaxCollectorListEntry() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteByte(level);
			guildInfo.Serialize(writer);
			writer.WriteInt(experienceForGuild);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			level = reader.ReadByte();
			guildInfo = new BasicGuildInformations();
			guildInfo.Deserialize(reader);
			experienceForGuild = reader.ReadInt();
		}

	}
}
