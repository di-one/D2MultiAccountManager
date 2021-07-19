namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyCancelInvitationMessage : AbstractPartyMessage
	{
		public new const uint Id = 7376;
		public override uint MessageId => Id;
		public ulong guestId { get; set; }

		public PartyCancelInvitationMessage(uint partyId, ulong guestId)
		{
			this.partyId = partyId;
			this.guestId = guestId;
		}

		public PartyCancelInvitationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(guestId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			guestId = reader.ReadVarULong();
		}

	}
}
