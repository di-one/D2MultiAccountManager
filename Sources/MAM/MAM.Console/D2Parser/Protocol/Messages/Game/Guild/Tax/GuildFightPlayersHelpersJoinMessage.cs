namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildFightPlayersHelpersJoinMessage : NetworkMessage
	{
		public const uint Id = 6219;
		public override uint MessageId => Id;
		public double fightId { get; set; }
		public CharacterMinimalPlusLookInformations playerInfo { get; set; }

		public GuildFightPlayersHelpersJoinMessage(double fightId, CharacterMinimalPlusLookInformations playerInfo)
		{
			this.fightId = fightId;
			this.playerInfo = playerInfo;
		}

		public GuildFightPlayersHelpersJoinMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(fightId);
			playerInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadDouble();
			playerInfo = new CharacterMinimalPlusLookInformations();
			playerInfo.Deserialize(reader);
		}

	}
}
