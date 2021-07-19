namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayMonsterNotAngryAtPlayerMessage : NetworkMessage
	{
		public const uint Id = 1147;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }
		public double monsterGroupId { get; set; }

		public GameRolePlayMonsterNotAngryAtPlayerMessage(ulong playerId, double monsterGroupId)
		{
			this.playerId = playerId;
			this.monsterGroupId = monsterGroupId;
		}

		public GameRolePlayMonsterNotAngryAtPlayerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(playerId);
			writer.WriteDouble(monsterGroupId);
		}

		public override void Deserialize(IDataReader reader)
		{
			playerId = reader.ReadVarULong();
			monsterGroupId = reader.ReadDouble();
		}

	}
}
