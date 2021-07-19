namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyUpdateMessage : AbstractPartyEventMessage
	{
		public new const uint Id = 5094;
		public override uint MessageId => Id;
		public PartyMemberInformations memberInformations { get; set; }

		public PartyUpdateMessage(uint partyId, PartyMemberInformations memberInformations)
		{
			this.partyId = partyId;
			this.memberInformations = memberInformations;
		}

		public PartyUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(memberInformations.TypeId);
			memberInformations.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			memberInformations = ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadShort());
			memberInformations.Deserialize(reader);
		}

	}
}
