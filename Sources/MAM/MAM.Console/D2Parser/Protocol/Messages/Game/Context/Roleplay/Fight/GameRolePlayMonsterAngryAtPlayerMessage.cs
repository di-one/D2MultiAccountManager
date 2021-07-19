namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayMonsterAngryAtPlayerMessage : NetworkMessage
	{
		public const uint Id = 3690;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }
		public double monsterGroupId { get; set; }
		public double angryStartTime { get; set; }
		public double attackTime { get; set; }

		public GameRolePlayMonsterAngryAtPlayerMessage(ulong playerId, double monsterGroupId, double angryStartTime, double attackTime)
		{
			this.playerId = playerId;
			this.monsterGroupId = monsterGroupId;
			this.angryStartTime = angryStartTime;
			this.attackTime = attackTime;
		}

		public GameRolePlayMonsterAngryAtPlayerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(playerId);
			writer.WriteDouble(monsterGroupId);
			writer.WriteDouble(angryStartTime);
			writer.WriteDouble(attackTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			playerId = reader.ReadVarULong();
			monsterGroupId = reader.ReadDouble();
			angryStartTime = reader.ReadDouble();
			attackTime = reader.ReadDouble();
		}

	}
}
