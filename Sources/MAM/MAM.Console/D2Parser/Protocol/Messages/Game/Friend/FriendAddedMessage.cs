namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendAddedMessage : NetworkMessage
	{
		public const uint Id = 2089;
		public override uint MessageId => Id;
		public FriendInformations friendAdded { get; set; }

		public FriendAddedMessage(FriendInformations friendAdded)
		{
			this.friendAdded = friendAdded;
		}

		public FriendAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(friendAdded.TypeId);
			friendAdded.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			friendAdded = ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
			friendAdded.Deserialize(reader);
		}

	}
}
