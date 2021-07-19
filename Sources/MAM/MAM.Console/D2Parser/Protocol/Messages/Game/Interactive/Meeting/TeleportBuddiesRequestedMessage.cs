namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TeleportBuddiesRequestedMessage : NetworkMessage
	{
		public const uint Id = 3681;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }
		public ulong inviterId { get; set; }
		public IEnumerable<ulong> invalidBuddiesIds { get; set; }

		public TeleportBuddiesRequestedMessage(ushort dungeonId, ulong inviterId, IEnumerable<ulong> invalidBuddiesIds)
		{
			this.dungeonId = dungeonId;
			this.inviterId = inviterId;
			this.invalidBuddiesIds = invalidBuddiesIds;
		}

		public TeleportBuddiesRequestedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(dungeonId);
			writer.WriteVarULong(inviterId);
			writer.WriteShort((short)invalidBuddiesIds.Count());
			foreach (var objectToSend in invalidBuddiesIds)
            {
				writer.WriteVarULong(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			dungeonId = reader.ReadVarUShort();
			inviterId = reader.ReadVarULong();
			var invalidBuddiesIdsCount = reader.ReadUShort();
			var invalidBuddiesIds_ = new ulong[invalidBuddiesIdsCount];
			for (var invalidBuddiesIdsIndex = 0; invalidBuddiesIdsIndex < invalidBuddiesIdsCount; invalidBuddiesIdsIndex++)
			{
				invalidBuddiesIds_[invalidBuddiesIdsIndex] = reader.ReadVarULong();
			}
			invalidBuddiesIds = invalidBuddiesIds_;
		}

	}
}
