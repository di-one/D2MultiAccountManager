namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendsListMessage : NetworkMessage
	{
		public const uint Id = 5325;
		public override uint MessageId => Id;
		public IEnumerable<FriendInformations> friendsList { get; set; }

		public FriendsListMessage(IEnumerable<FriendInformations> friendsList)
		{
			this.friendsList = friendsList;
		}

		public FriendsListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)friendsList.Count());
			foreach (var objectToSend in friendsList)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var friendsListCount = reader.ReadUShort();
			var friendsList_ = new FriendInformations[friendsListCount];
			for (var friendsListIndex = 0; friendsListIndex < friendsListCount; friendsListIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				friendsList_[friendsListIndex] = objectToAdd;
			}
			friendsList = friendsList_;
		}

	}
}
