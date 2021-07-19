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
	public class MapRunningFightDetailsExtendedMessage : MapRunningFightDetailsMessage
	{
		public new const uint Id = 9242;
		public override uint MessageId => Id;
		public IEnumerable<NamedPartyTeam> namedPartyTeams { get; set; }

		public MapRunningFightDetailsExtendedMessage(ushort fightId, IEnumerable<GameFightFighterLightInformations> attackers, IEnumerable<GameFightFighterLightInformations> defenders, IEnumerable<NamedPartyTeam> namedPartyTeams)
		{
			this.fightId = fightId;
			this.attackers = attackers;
			this.defenders = defenders;
			this.namedPartyTeams = namedPartyTeams;
		}

		public MapRunningFightDetailsExtendedMessage() { }

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
