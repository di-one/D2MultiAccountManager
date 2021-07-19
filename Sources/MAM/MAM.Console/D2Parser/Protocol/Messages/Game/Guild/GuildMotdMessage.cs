namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildMotdMessage : SocialNoticeMessage
	{
		public new const uint Id = 1592;
		public override uint MessageId => Id;

		public GuildMotdMessage(string content, int timestamp, ulong memberId, string memberName)
		{
			this.content = content;
			this.timestamp = timestamp;
			this.memberId = memberId;
			this.memberName = memberName;
		}

		public GuildMotdMessage() { }

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
