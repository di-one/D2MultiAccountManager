namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage : GameRolePlayArenaUpdatePlayerInfosMessage
	{
		public new const uint Id = 8647;
		public override uint MessageId => Id;
		public ArenaRankInfos team { get; set; }
		public ArenaRankInfos duel { get; set; }

		public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(ArenaRankInfos solo, ArenaRankInfos team, ArenaRankInfos duel)
		{
			this.solo = solo;
			this.team = team;
			this.duel = duel;
		}

		public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			team.Serialize(writer);
			duel.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			team = new ArenaRankInfos();
			team.Deserialize(reader);
			duel = new ArenaRankInfos();
			duel.Deserialize(reader);
		}

	}
}
