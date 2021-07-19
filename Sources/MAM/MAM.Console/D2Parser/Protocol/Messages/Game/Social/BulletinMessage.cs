namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BulletinMessage : SocialNoticeMessage
	{
		public new const uint Id = 1259;
		public override uint MessageId => Id;
		public int lastNotifiedTimestamp { get; set; }

		public BulletinMessage(string content, int timestamp, ulong memberId, string memberName, int lastNotifiedTimestamp)
		{
			this.content = content;
			this.timestamp = timestamp;
			this.memberId = memberId;
			this.memberName = memberName;
			this.lastNotifiedTimestamp = lastNotifiedTimestamp;
		}

		public BulletinMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(lastNotifiedTimestamp);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			lastNotifiedTimestamp = reader.ReadInt();
		}

	}
}
