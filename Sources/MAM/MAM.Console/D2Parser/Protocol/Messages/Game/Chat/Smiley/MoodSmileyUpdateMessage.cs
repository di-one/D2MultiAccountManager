namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MoodSmileyUpdateMessage : NetworkMessage
	{
		public const uint Id = 8472;
		public override uint MessageId => Id;
		public int accountId { get; set; }
		public ulong playerId { get; set; }
		public ushort smileyId { get; set; }

		public MoodSmileyUpdateMessage(int accountId, ulong playerId, ushort smileyId)
		{
			this.accountId = accountId;
			this.playerId = playerId;
			this.smileyId = smileyId;
		}

		public MoodSmileyUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(accountId);
			writer.WriteVarULong(playerId);
			writer.WriteVarUShort(smileyId);
		}

		public override void Deserialize(IDataReader reader)
		{
			accountId = reader.ReadInt();
			playerId = reader.ReadVarULong();
			smileyId = reader.ReadVarUShort();
		}

	}
}
