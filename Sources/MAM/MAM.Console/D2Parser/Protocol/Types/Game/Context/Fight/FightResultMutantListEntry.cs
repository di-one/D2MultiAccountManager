namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightResultMutantListEntry : FightResultFighterListEntry
	{
		public new const short Id = 2372;
		public override short TypeId => Id;
		public ushort level { get; set; }

		public FightResultMutantListEntry(ushort outcome, sbyte wave, FightLoot rewards, double objectId, bool alive, ushort level)
		{
			this.outcome = outcome;
			this.wave = wave;
			this.rewards = rewards;
			this.objectId = objectId;
			this.alive = alive;
			this.level = level;
		}

		public FightResultMutantListEntry() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(level);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			level = reader.ReadVarUShort();
		}

	}
}
