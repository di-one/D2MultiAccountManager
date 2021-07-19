namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatCommunityChannelSetCommunityRequestMessage : NetworkMessage
	{
		public const uint Id = 6181;
		public override uint MessageId => Id;
		public short communityId { get; set; }

		public ChatCommunityChannelSetCommunityRequestMessage(short communityId)
		{
			this.communityId = communityId;
		}

		public ChatCommunityChannelSetCommunityRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(communityId);
		}

		public override void Deserialize(IDataReader reader)
		{
			communityId = reader.ReadShort();
		}

	}
}
