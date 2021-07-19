namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightUpdateTeamMessage : NetworkMessage
	{
		public const uint Id = 6859;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }
		public FightTeamInformations team { get; set; }

		public GameFightUpdateTeamMessage(ushort fightId, FightTeamInformations team)
		{
			this.fightId = fightId;
			this.team = team;
		}

		public GameFightUpdateTeamMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
			team.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
			team = new FightTeamInformations();
			team.Deserialize(reader);
		}

	}
}
