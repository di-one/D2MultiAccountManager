namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyModifiableStatusMessage : AbstractPartyMessage
	{
		public new const uint Id = 240;
		public override uint MessageId => Id;
		public bool enabled { get; set; }

		public PartyModifiableStatusMessage(uint partyId, bool enabled)
		{
			this.partyId = partyId;
			this.enabled = enabled;
		}

		public PartyModifiableStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(enabled);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			enabled = reader.ReadBoolean();
		}

	}
}
