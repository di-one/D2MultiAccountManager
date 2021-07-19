namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyKickedByMessage : AbstractPartyMessage
	{
		public new const uint Id = 1519;
		public override uint MessageId => Id;
		public ulong kickerId { get; set; }

		public PartyKickedByMessage(uint partyId, ulong kickerId)
		{
			this.partyId = partyId;
			this.kickerId = kickerId;
		}

		public PartyKickedByMessage() { }

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
