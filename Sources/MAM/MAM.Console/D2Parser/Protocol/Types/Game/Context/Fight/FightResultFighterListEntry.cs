namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightResultFighterListEntry : FightResultListEntry
	{
		public new const short Id = 2947;
		public override short TypeId => Id;
		public double objectId { get; set; }
		public bool alive { get; set; }

		public FightResultFighterListEntry(ushort outcome, sbyte wave, FightLoot rewards, double objectId, bool alive)
		{
			this.outcome = outcome;
			this.wave = wave;
			this.rewards = rewards;
			this.objectId = objectId;
			this.alive = alive;
		}

		public FightResultFighterListEntry() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(objectId);
			writer.WriteBoolean(alive);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectId = reader.ReadDouble();
			alive = reader.ReadBoolean();
		}

	}
}
