namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TeleportToBuddyOfferMessage : NetworkMessage
	{
		public const uint Id = 4964;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }
		public ulong buddyId { get; set; }
		public uint timeLeft { get; set; }

		public TeleportToBuddyOfferMessage(ushort dungeonId, ulong buddyId, uint timeLeft)
		{
			this.dungeonId = dungeonId;
			this.buddyId = buddyId;
			this.timeLeft = timeLeft;
		}

		public TeleportToBuddyOfferMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(dungeonId);
			writer.WriteVarULong(buddyId);
			writer.WriteVarUInt(timeLeft);
		}

		public override void Deserialize(IDataReader reader)
		{
			dungeonId = reader.ReadVarUShort();
			buddyId = reader.ReadVarULong();
			timeLeft = reader.ReadVarUInt();
		}

	}
}
