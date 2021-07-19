namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyAcceptInvitationMessage : AbstractPartyMessage
	{
		public new const uint Id = 5016;
		public override uint MessageId => Id;

		public PartyAcceptInvitationMessage(uint partyId)
		{
			this.partyId = partyId;
		}

		public PartyAcceptInvitationMessage() { }

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
