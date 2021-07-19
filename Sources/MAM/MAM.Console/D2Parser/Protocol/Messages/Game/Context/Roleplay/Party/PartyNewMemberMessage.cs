namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyNewMemberMessage : PartyUpdateMessage
	{
		public new const uint Id = 7489;
		public override uint MessageId => Id;

		public PartyNewMemberMessage(uint partyId, PartyMemberInformations memberInformations)
		{
			this.partyId = partyId;
			this.memberInformations = memberInformations;
		}

		public PartyNewMemberMessage() { }

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
