namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceMotdSetErrorMessage : SocialNoticeSetErrorMessage
	{
		public new const uint Id = 3284;
		public override uint MessageId => Id;

		public AllianceMotdSetErrorMessage(sbyte reason)
		{
			this.reason = reason;
		}

		public AllianceMotdSetErrorMessage() { }

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
