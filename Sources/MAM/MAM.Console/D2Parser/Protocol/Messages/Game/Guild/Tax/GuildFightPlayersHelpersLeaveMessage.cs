namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildFightPlayersHelpersLeaveMessage : NetworkMessage
	{
		public const uint Id = 1445;
		public override uint MessageId => Id;
		public double fightId { get; set; }
		public ulong playerId { get; set; }

		public GuildFightPlayersHelpersLeaveMessage(double fightId, ulong playerId)
		{
			this.fightId = fightId;
			this.playerId = playerId;
		}

		public GuildFightPlayersHelpersLeaveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(fightId);
			writer.WriteVarULong(playerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadDouble();
			playerId = reader.ReadVarULong();
		}

	}
}
