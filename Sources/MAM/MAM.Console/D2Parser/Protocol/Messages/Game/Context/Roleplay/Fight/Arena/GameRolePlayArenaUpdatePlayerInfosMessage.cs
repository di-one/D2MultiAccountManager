namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayArenaUpdatePlayerInfosMessage : NetworkMessage
	{
		public const uint Id = 685;
		public override uint MessageId => Id;
		public ArenaRankInfos solo { get; set; }

		public GameRolePlayArenaUpdatePlayerInfosMessage(ArenaRankInfos solo)
		{
			this.solo = solo;
		}

		public GameRolePlayArenaUpdatePlayerInfosMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			solo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			solo = new ArenaRankInfos();
			solo.Deserialize(reader);
		}

	}
}
