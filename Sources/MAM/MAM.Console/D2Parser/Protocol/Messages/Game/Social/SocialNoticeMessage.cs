namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SocialNoticeMessage : NetworkMessage
	{
		public const uint Id = 9413;
		public override uint MessageId => Id;
		public string content { get; set; }
		public int timestamp { get; set; }
		public ulong memberId { get; set; }
		public string memberName { get; set; }

		public SocialNoticeMessage(string content, int timestamp, ulong memberId, string memberName)
		{
			this.content = content;
			this.timestamp = timestamp;
			this.memberId = memberId;
			this.memberName = memberName;
		}

		public SocialNoticeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(content);
			writer.WriteInt(timestamp);
			writer.WriteVarULong(memberId);
			writer.WriteUTF(memberName);
		}

		public override void Deserialize(IDataReader reader)
		{
			content = reader.ReadUTF();
			timestamp = reader.ReadInt();
			memberId = reader.ReadVarULong();
			memberName = reader.ReadUTF();
		}

	}
}
