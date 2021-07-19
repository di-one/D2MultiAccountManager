namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyInvitationCancelledForGuestMessage : AbstractPartyMessage
	{
		public new const uint Id = 8562;
		public override uint MessageId => Id;
		public ulong cancelerId { get; set; }

		public PartyInvitationCancelledForGuestMessage(uint partyId, ulong cancelerId)
		{
			this.partyId = partyId;
			this.cancelerId = cancelerId;
		}

		public PartyInvitationCancelledForGuestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(cancelerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			cancelerId = reader.ReadVarULong();
		}

	}
}
