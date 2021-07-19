namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractPartyEventMessage : AbstractPartyMessage
	{
		public new const uint Id = 8018;
		public override uint MessageId => Id;

		public AbstractPartyEventMessage(uint partyId)
		{
			this.partyId = partyId;
		}

		public AbstractPartyEventMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
