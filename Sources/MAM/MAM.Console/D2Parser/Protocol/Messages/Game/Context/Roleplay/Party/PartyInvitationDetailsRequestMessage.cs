namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyInvitationDetailsRequestMessage : AbstractPartyMessage
	{
		public new const uint Id = 8474;
		public override uint MessageId => Id;

		public PartyInvitationDetailsRequestMessage(uint partyId)
		{
			this.partyId = partyId;
		}

		public PartyInvitationDetailsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
