namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayAttackMonsterRequestMessage : NetworkMessage
	{
		public const uint Id = 3441;
		public override uint MessageId => Id;
		public double monsterGroupId { get; set; }

		public GameRolePlayAttackMonsterRequestMessage(double monsterGroupId)
		{
			this.monsterGroupId = monsterGroupId;
		}

		public GameRolePlayAttackMonsterRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(monsterGroupId);
		}

		public override void Deserialize(IDataReader reader)
		{
			monsterGroupId = reader.ReadDouble();
		}

	}
}
