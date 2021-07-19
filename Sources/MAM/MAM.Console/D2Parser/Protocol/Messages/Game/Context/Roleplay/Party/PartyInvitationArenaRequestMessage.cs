namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyInvitationArenaRequestMessage : PartyInvitationRequestMessage
	{
		public new const uint Id = 7864;
		public override uint MessageId => Id;

		public PartyInvitationArenaRequestMessage(AbstractPlayerSearchInformation target)
		{
			this.target = target;
		}

		public PartyInvitationArenaRequestMessage() { }

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
