namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TeleportToBuddyAnswerMessage : NetworkMessage
	{
		public const uint Id = 6804;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }
		public ulong buddyId { get; set; }
		public bool accept { get; set; }

		public TeleportToBuddyAnswerMessage(ushort dungeonId, ulong buddyId, bool accept)
		{
			this.dungeonId = dungeonId;
			this.buddyId = buddyId;
			this.accept = accept;
		}

		public TeleportToBuddyAnswerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(dungeonId);
			writer.WriteVarULong(buddyId);
			writer.WriteBoolean(accept);
		}

		public override void Deserialize(IDataReader reader)
		{
			dungeonId = reader.ReadVarUShort();
			buddyId = reader.ReadVarULong();
			accept = reader.ReadBoolean();
		}

	}
}
