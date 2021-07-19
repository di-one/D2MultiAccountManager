namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyRestrictedMessage : AbstractPartyMessage
	{
		public new const uint Id = 811;
		public override uint MessageId => Id;
		public bool restricted { get; set; }

		public PartyRestrictedMessage(uint partyId, bool restricted)
		{
			this.partyId = partyId;
			this.restricted = restricted;
		}

		public PartyRestrictedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(restricted);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			restricted = reader.ReadBoolean();
		}

	}
}
