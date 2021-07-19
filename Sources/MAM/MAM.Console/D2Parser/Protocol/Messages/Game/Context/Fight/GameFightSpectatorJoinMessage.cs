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
	public class GameFightSpectatorJoinMessage : GameFightJoinMessage
	{
		public new const uint Id = 5142;
		public override uint MessageId => Id;
		public IEnumerable<NamedPartyTeam> namedPartyTeams { get; set; }

		public GameFightSpectatorJoinMessage(bool isTeamPhase, bool canBeCancelled, bool canSayReady, bool isFightStarted, short timeMaxBeforeFightStart, sbyte fightType, IEnumerable<NamedPartyTeam> namedPartyTeams)
		{
			this.isTeamPhase = isTeamPhase;
			this.canBeCancelled = canBeCancelled;
			this.canSayReady = canSayReady;
			this.isFightStarted = isFightStarted;
			this.timeMaxBeforeFightStart = timeMaxBeforeFightStart;
			this.fightType = fightType;
			this.namedPartyTeams = namedPartyTeams;
		}

		public GameFightSpectatorJoinMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)namedPartyTeams.Count());
			foreach (var objectToSend in namedPartyTeams)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var namedPartyTeamsCount = reader.ReadUShort();
			var namedPartyTeams_ = new NamedPartyTeam[namedPartyTeamsCount];
			for (var namedPartyTeamsIndex = 0; namedPartyTeamsIndex < namedPartyTeamsCount; namedPartyTeamsIndex++)
			{
				var objectToAdd = new NamedPartyTeam();
				objectToAdd.Deserialize(reader);
				namedPartyTeams_[namedPartyTeamsIndex] = objectToAdd;
			}
			namedPartyTeams = namedPartyTeams_;
		}

	}
}
