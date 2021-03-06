namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceMembershipMessage : AllianceJoinedMessage
	{
		public new const uint Id = 3816;
		public override uint MessageId => Id;

		public AllianceMembershipMessage(AllianceInformations allianceInfo, bool enabled, uint leadingGuildId)
		{
			this.allianceInfo = allianceInfo;
			this.enabled = enabled;
			this.leadingGuildId = leadingGuildId;
		}

		public AllianceMembershipMessage() { }

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
