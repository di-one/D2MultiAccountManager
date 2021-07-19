namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyNewGuestMessage : AbstractPartyEventMessage
	{
		public new const uint Id = 4272;
		public override uint MessageId => Id;
		public PartyGuestInformations guest { get; set; }

		public PartyNewGuestMessage(uint partyId, PartyGuestInformations guest)
		{
			this.partyId = partyId;
			this.guest = guest;
		}

		public PartyNewGuestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			guest.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			guest = new PartyGuestInformations();
			guest.Deserialize(reader);
		}

	}
}
