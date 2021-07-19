namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayPlayerFightFriendlyRequestedMessage : NetworkMessage
	{
		public const uint Id = 6705;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }
		public ulong sourceId { get; set; }
		public ulong targetId { get; set; }

		public GameRolePlayPlayerFightFriendlyRequestedMessage(ushort fightId, ulong sourceId, ulong targetId)
		{
			this.fightId = fightId;
			this.sourceId = sourceId;
			this.targetId = targetId;
		}

		public GameRolePlayPlayerFightFriendlyRequestedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
			writer.WriteVarULong(sourceId);
			writer.WriteVarULong(targetId);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
			sourceId = reader.ReadVarULong();
			targetId = reader.ReadVarULong();
		}

	}
}
