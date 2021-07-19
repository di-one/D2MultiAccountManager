namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdolPartyRefreshMessage : NetworkMessage
	{
		public const uint Id = 5681;
		public override uint MessageId => Id;
		public PartyIdol partyIdol { get; set; }

		public IdolPartyRefreshMessage(PartyIdol partyIdol)
		{
			this.partyIdol = partyIdol;
		}

		public IdolPartyRefreshMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			partyIdol.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			partyIdol = new PartyIdol();
			partyIdol.Deserialize(reader);
		}

	}
}
