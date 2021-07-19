namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyLeaveRequestMessage : AbstractPartyMessage
	{
		public new const uint Id = 6323;
		public override uint MessageId => Id;

		public PartyLeaveRequestMessage(uint partyId)
		{
			this.partyId = partyId;
		}

		public PartyLeaveRequestMessage() { }

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
