namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChallengeFightJoinRefusedMessage : NetworkMessage
	{
		public const uint Id = 1224;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }
		public sbyte reason { get; set; }

		public ChallengeFightJoinRefusedMessage(ulong playerId, sbyte reason)
		{
			this.playerId = playerId;
			this.reason = reason;
		}

		public ChallengeFightJoinRefusedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(playerId);
			writer.WriteSByte(reason);
		}

		public override void Deserialize(IDataReader reader)
		{
			playerId = reader.ReadVarULong();
			reason = reader.ReadSByte();
		}

	}
}
