namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class NamedPartyTeamWithOutcome
	{
		public const short Id  = 7451;
		public virtual short TypeId => Id;
		public NamedPartyTeam team { get; set; }
		public ushort outcome { get; set; }

		public NamedPartyTeamWithOutcome(NamedPartyTeam team, ushort outcome)
		{
			this.team = team;
			this.outcome = outcome;
		}

		public NamedPartyTeamWithOutcome() { }

		public virtual void Serialize(IDataWriter writer)
		{
			team.Serialize(writer);
			writer.WriteVarUShort(outcome);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			team = new NamedPartyTeam();
			team.Deserialize(reader);
			outcome = reader.ReadVarUShort();
		}

	}
}
