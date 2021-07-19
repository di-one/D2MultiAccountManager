namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayAggressionMessage : NetworkMessage
	{
		public const uint Id = 6230;
		public override uint MessageId => Id;
		public ulong attackerId { get; set; }
		public ulong defenderId { get; set; }

		public GameRolePlayAggressionMessage(ulong attackerId, ulong defenderId)
		{
			this.attackerId = attackerId;
			this.defenderId = defenderId;
		}

		public GameRolePlayAggressionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(attackerId);
			writer.WriteVarULong(defenderId);
		}

		public override void Deserialize(IDataReader reader)
		{
			attackerId = reader.ReadVarULong();
			defenderId = reader.ReadVarULong();
		}

	}
}
