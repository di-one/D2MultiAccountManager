namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightResultListEntry
	{
		public const short Id  = 4588;
		public virtual short TypeId => Id;
		public ushort outcome { get; set; }
		public sbyte wave { get; set; }
		public FightLoot rewards { get; set; }

		public FightResultListEntry(ushort outcome, sbyte wave, FightLoot rewards)
		{
			this.outcome = outcome;
			this.wave = wave;
			this.rewards = rewards;
		}

		public FightResultListEntry() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(outcome);
			writer.WriteSByte(wave);
			rewards.Serialize(writer);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			outcome = reader.ReadVarUShort();
			wave = reader.ReadSByte();
			rewards = new FightLoot();
			rewards.Deserialize(reader);
		}

	}
}
