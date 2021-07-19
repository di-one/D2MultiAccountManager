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
	public class GameFightEndMessage : NetworkMessage
	{
		public const uint Id = 788;
		public override uint MessageId => Id;
		public int duration { get; set; }
		public short rewardRate { get; set; }
		public short lootShareLimitMalus { get; set; }
		public IEnumerable<FightResultListEntry> results { get; set; }
		public IEnumerable<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes { get; set; }

		public GameFightEndMessage(int duration, short rewardRate, short lootShareLimitMalus, IEnumerable<FightResultListEntry> results, IEnumerable<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes)
		{
			this.duration = duration;
			this.rewardRate = rewardRate;
			this.lootShareLimitMalus = lootShareLimitMalus;
			this.results = results;
			this.namedPartyTeamsOutcomes = namedPartyTeamsOutcomes;
		}

		public GameFightEndMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(duration);
			writer.WriteVarShort(rewardRate);
			writer.WriteShort(lootShareLimitMalus);
			writer.WriteShort((short)results.Count());
			foreach (var objectToSend in results)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)namedPartyTeamsOutcomes.Count());
			foreach (var objectToSend in namedPartyTeamsOutcomes)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			duration = reader.ReadInt();
			rewardRate = reader.ReadVarShort();
			lootShareLimitMalus = reader.ReadShort();
			var resultsCount = reader.ReadUShort();
			var results_ = new FightResultListEntry[resultsCount];
			for (var resultsIndex = 0; resultsIndex < resultsCount; resultsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<FightResultListEntry>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				results_[resultsIndex] = objectToAdd;
			}
			results = results_;
			var namedPartyTeamsOutcomesCount = reader.ReadUShort();
			var namedPartyTeamsOutcomes_ = new NamedPartyTeamWithOutcome[namedPartyTeamsOutcomesCount];
			for (var namedPartyTeamsOutcomesIndex = 0; namedPartyTeamsOutcomesIndex < namedPartyTeamsOutcomesCount; namedPartyTeamsOutcomesIndex++)
			{
				var objectToAdd = new NamedPartyTeamWithOutcome();
				objectToAdd.Deserialize(reader);
				namedPartyTeamsOutcomes_[namedPartyTeamsOutcomesIndex] = objectToAdd;
			}
			namedPartyTeamsOutcomes = namedPartyTeamsOutcomes_;
		}

	}
}
