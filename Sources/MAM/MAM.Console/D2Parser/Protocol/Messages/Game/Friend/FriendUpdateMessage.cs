namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendUpdateMessage : NetworkMessage
	{
		public const uint Id = 4416;
		public override uint MessageId => Id;
		public FriendInformations friendUpdated { get; set; }

		public FriendUpdateMessage(FriendInformations friendUpdated)
		{
			this.friendUpdated = friendUpdated;
		}

		public FriendUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(friendUpdated.TypeId);
			friendUpdated.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			friendUpdated = ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
			friendUpdated.Deserialize(reader);
		}

	}
}
