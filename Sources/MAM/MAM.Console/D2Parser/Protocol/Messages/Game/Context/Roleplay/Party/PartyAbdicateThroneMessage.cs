namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyAbdicateThroneMessage : AbstractPartyMessage
	{
		public new const uint Id = 3225;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }

		public PartyAbdicateThroneMessage(uint partyId, ulong playerId)
		{
			this.partyId = partyId;
			this.playerId = playerId;
		}

		public PartyAbdicateThroneMessage() { }

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
