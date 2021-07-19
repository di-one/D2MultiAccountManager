namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyLoyaltyStatusMessage : AbstractPartyMessage
	{
		public new const uint Id = 7878;
		public override uint MessageId => Id;
		public bool loyal { get; set; }

		public PartyLoyaltyStatusMessage(uint partyId, bool loyal)
		{
			this.partyId = partyId;
			this.loyal = loyal;
		}

		public PartyLoyaltyStatusMessage() { }

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
