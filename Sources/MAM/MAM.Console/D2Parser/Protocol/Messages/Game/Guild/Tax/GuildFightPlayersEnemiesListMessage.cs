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
	public class GuildFightPlayersEnemiesListMessage : NetworkMessage
	{
		public const uint Id = 3648;
		public override uint MessageId => Id;
		public double fightId { get; set; }
		public IEnumerable<CharacterMinimalPlusLookInformations> playerInfo { get; set; }

		public GuildFightPlayersEnemiesListMessage(double fightId, IEnumerable<CharacterMinimalPlusLookInformations> playerInfo)
		{
			this.fightId = fightId;
			this.playerInfo = playerInfo;
		}

		public GuildFightPlayersEnemiesListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(fightId);
			writer.WriteShort((short)playerInfo.Count());
			foreach (var objectToSend in playerInfo)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadDouble();
			var playerInfoCount = reader.ReadUShort();
			var playerInfo_ = new CharacterMinimalPlusLookInformations[playerInfoCount];
			for (var playerInfoIndex = 0; playerInfoIndex < playerInfoCount; playerInfoIndex++)
			{
				var objectToAdd = new CharacterMinimalPlusLookInformations();
				objectToAdd.Deserialize(reader);
				playerInfo_[playerInfoIndex] = objectToAdd;
			}
			playerInfo = playerInfo_;
		}

	}
}
