namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyFollowThisMemberRequestMessage : PartyFollowMemberRequestMessage
	{
		public new const uint Id = 3249;
		public override uint MessageId => Id;
		public bool enabled { get; set; }

		public PartyFollowThisMemberRequestMessage(uint partyId, ulong playerId, bool enabled)
		{
			this.partyId = partyId;
			this.playerId = playerId;
			this.enabled = enabled;
		}

		public PartyFollowThisMemberRequestMessage() { }

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
