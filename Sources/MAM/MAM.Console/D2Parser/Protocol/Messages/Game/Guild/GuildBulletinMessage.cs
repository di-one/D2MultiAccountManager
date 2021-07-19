namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildBulletinMessage : BulletinMessage
	{
		public new const uint Id = 5925;
		public override uint MessageId => Id;

		public GuildBulletinMessage(string content, int timestamp, ulong memberId, string memberName, int lastNotifiedTimestamp)
		{
			this.content = content;
			this.timestamp = timestamp;
			this.memberId = memberId;
			this.memberName = memberName;
			this.lastNotifiedTimestamp = lastNotifiedTimestamp;
		}

		public GuildBulletinMessage() { }

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
