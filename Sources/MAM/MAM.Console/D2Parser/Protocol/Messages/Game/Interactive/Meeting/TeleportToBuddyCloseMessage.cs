namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TeleportToBuddyCloseMessage : NetworkMessage
	{
		public const uint Id = 2978;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }
		public ulong buddyId { get; set; }

		public TeleportToBuddyCloseMessage(ushort dungeonId, ulong buddyId)
		{
			this.dungeonId = dungeonId;
			this.buddyId = buddyId;
		}

		public TeleportToBuddyCloseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(dungeonId);
			writer.WriteVarULong(buddyId);
		}

		public override void Deserialize(IDataReader reader)
		{
			dungeonId = reader.ReadVarUShort();
			buddyId = reader.ReadVarULong();
		}

	}
}
