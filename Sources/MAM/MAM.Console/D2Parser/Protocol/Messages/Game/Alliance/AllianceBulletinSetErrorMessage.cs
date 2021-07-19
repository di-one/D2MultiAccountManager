namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceBulletinSetErrorMessage : SocialNoticeSetErrorMessage
	{
		public new const uint Id = 9312;
		public override uint MessageId => Id;

		public AllianceBulletinSetErrorMessage(sbyte reason)
		{
			this.reason = reason;
		}

		public AllianceBulletinSetErrorMessage() { }

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
