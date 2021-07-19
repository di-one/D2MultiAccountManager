namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyLocateMembersRequestMessage : AbstractPartyMessage
	{
		public new const uint Id = 4010;
		public override uint MessageId => Id;

		public PartyLocateMembersRequestMessage(uint partyId)
		{
			this.partyId = partyId;
		}

		public PartyLocateMembersRequestMessage() { }

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
