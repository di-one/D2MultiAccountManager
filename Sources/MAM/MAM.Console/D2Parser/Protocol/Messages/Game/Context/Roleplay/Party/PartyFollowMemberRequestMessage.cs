namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyFollowMemberRequestMessage : AbstractPartyMessage
	{
		public new const uint Id = 5257;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }

		public PartyFollowMemberRequestMessage(uint partyId, ulong playerId)
		{
			this.partyId = partyId;
			this.playerId = playerId;
		}

		public PartyFollowMemberRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(playerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerId = reader.ReadVarULong();
		}

	}
}
