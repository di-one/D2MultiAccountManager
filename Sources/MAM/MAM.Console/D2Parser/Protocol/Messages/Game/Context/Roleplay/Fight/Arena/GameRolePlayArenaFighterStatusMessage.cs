namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayArenaFighterStatusMessage : NetworkMessage
	{
		public const uint Id = 414;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }
		public double playerId { get; set; }
		public bool accepted { get; set; }

		public GameRolePlayArenaFighterStatusMessage(ushort fightId, double playerId, bool accepted)
		{
			this.fightId = fightId;
			this.playerId = playerId;
			this.accepted = accepted;
		}

		public GameRolePlayArenaFighterStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
			writer.WriteDouble(playerId);
			writer.WriteBoolean(accepted);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
			playerId = reader.ReadDouble();
			accepted = reader.ReadBoolean();
		}

	}
}
