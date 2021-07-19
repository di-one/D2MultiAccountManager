namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachGameFightEndMessage : GameFightEndMessage
	{
		public new const uint Id = 1630;
		public override uint MessageId => Id;
		public int budget { get; set; }

		public BreachGameFightEndMessage(int duration, short rewardRate, short lootShareLimitMalus, IEnumerable<FightResultListEntry> results, IEnumerable<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes, int budget)
		{
			this.duration = duration;
			this.rewardRate = rewardRate;
			this.lootShareLimitMalus = lootShareLimitMalus;
			this.results = results;
			this.namedPartyTeamsOutcomes = namedPartyTeamsOutcomes;
			this.budget = budget;
		}

		public BreachGameFightEndMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(budget);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			budget = reader.ReadInt();
		}

	}
}
