namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildMotdSetErrorMessage : SocialNoticeSetErrorMessage
	{
		public new const uint Id = 4213;
		public override uint MessageId => Id;

		public GuildMotdSetErrorMessage(sbyte reason)
		{
			this.reason = reason;
		}

		public GuildMotdSetErrorMessage() { }

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
