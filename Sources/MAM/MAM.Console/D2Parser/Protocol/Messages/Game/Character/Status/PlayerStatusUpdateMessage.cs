namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PlayerStatusUpdateMessage : NetworkMessage
	{
		public const uint Id = 626;
		public override uint MessageId => Id;
		public int accountId { get; set; }
		public ulong playerId { get; set; }
		public PlayerStatus status { get; set; }

		public PlayerStatusUpdateMessage(int accountId, ulong playerId, PlayerStatus status)
		{
			this.accountId = accountId;
			this.playerId = playerId;
			this.status = status;
		}

		public PlayerStatusUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(accountId);
			writer.WriteVarULong(playerId);
			writer.WriteShort(status.TypeId);
			status.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			accountId = reader.ReadInt();
			playerId = reader.ReadVarULong();
			status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
			status.Deserialize(reader);
		}

	}
}
