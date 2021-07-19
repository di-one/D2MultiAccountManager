namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayPlayerFightFriendlyAnsweredMessage : NetworkMessage
	{
		public const uint Id = 831;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }
		public ulong sourceId { get; set; }
		public ulong targetId { get; set; }
		public bool accept { get; set; }

		public GameRolePlayPlayerFightFriendlyAnsweredMessage(ushort fightId, ulong sourceId, ulong targetId, bool accept)
		{
			this.fightId = fightId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.accept = accept;
		}

		public GameRolePlayPlayerFightFriendlyAnsweredMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
			writer.WriteVarULong(sourceId);
			writer.WriteVarULong(targetId);
			writer.WriteBoolean(accept);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
			sourceId = reader.ReadVarULong();
			targetId = reader.ReadVarULong();
			accept = reader.ReadBoolean();
		}

	}
}
