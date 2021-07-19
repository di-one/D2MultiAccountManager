namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyMemberEjectedMessage : PartyMemberRemoveMessage
	{
		public new const uint Id = 9776;
		public override uint MessageId => Id;
		public ulong kickerId { get; set; }

		public PartyMemberEjectedMessage(uint partyId, ulong leavingPlayerId, ulong kickerId)
		{
			this.partyId = partyId;
			this.leavingPlayerId = leavingPlayerId;
			this.kickerId = kickerId;
		}

		public PartyMemberEjectedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(kickerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			kickerId = reader.ReadVarULong();
		}

	}
}
