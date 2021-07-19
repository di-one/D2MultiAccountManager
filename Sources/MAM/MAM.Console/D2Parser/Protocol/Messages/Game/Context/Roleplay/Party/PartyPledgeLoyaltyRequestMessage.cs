namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyPledgeLoyaltyRequestMessage : AbstractPartyMessage
	{
		public new const uint Id = 9887;
		public override uint MessageId => Id;
		public bool loyal { get; set; }

		public PartyPledgeLoyaltyRequestMessage(uint partyId, bool loyal)
		{
			this.partyId = partyId;
			this.loyal = loyal;
		}

		public PartyPledgeLoyaltyRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(loyal);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			loyal = reader.ReadBoolean();
		}

	}
}
