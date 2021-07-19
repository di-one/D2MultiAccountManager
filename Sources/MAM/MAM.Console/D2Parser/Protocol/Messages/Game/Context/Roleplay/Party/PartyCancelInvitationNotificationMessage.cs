namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyCancelInvitationNotificationMessage : AbstractPartyEventMessage
	{
		public new const uint Id = 1017;
		public override uint MessageId => Id;
		public ulong cancelerId { get; set; }
		public ulong guestId { get; set; }

		public PartyCancelInvitationNotificationMessage(uint partyId, ulong cancelerId, ulong guestId)
		{
			this.partyId = partyId;
			this.cancelerId = cancelerId;
			this.guestId = guestId;
		}

		public PartyCancelInvitationNotificationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(cancelerId);
			writer.WriteVarULong(guestId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			cancelerId = reader.ReadVarULong();
			guestId = reader.ReadVarULong();
		}

	}
}
