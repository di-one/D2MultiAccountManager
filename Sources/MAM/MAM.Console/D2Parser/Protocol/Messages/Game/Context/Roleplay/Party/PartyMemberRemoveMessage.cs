namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyMemberRemoveMessage : AbstractPartyEventMessage
	{
		public new const uint Id = 6103;
		public override uint MessageId => Id;
		public ulong leavingPlayerId { get; set; }

		public PartyMemberRemoveMessage(uint partyId, ulong leavingPlayerId)
		{
			this.partyId = partyId;
			this.leavingPlayerId = leavingPlayerId;
		}

		public PartyMemberRemoveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(leavingPlayerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			leavingPlayerId = reader.ReadVarULong();
		}

	}
}
