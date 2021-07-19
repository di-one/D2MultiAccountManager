namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildBulletinSetErrorMessage : SocialNoticeSetErrorMessage
	{
		public new const uint Id = 8149;
		public override uint MessageId => Id;

		public GuildBulletinSetErrorMessage(sbyte reason)
		{
			this.reason = reason;
		}

		public GuildBulletinSetErrorMessage() { }

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
