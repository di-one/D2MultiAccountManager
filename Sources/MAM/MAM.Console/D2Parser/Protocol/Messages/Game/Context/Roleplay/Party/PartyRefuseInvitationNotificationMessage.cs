namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyRefuseInvitationNotificationMessage : AbstractPartyEventMessage
	{
		public new const uint Id = 7135;
		public override uint MessageId => Id;
		public ulong guestId { get; set; }

		public PartyRefuseInvitationNotificationMessage(uint partyId, ulong guestId)
		{
			this.partyId = partyId;
			this.guestId = guestId;
		}

		public PartyRefuseInvitationNotificationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(guestId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			guestId = reader.ReadVarULong();
		}

	}
}
