namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendDeleteRequestMessage : NetworkMessage
	{
		public const uint Id = 9483;
		public override uint MessageId => Id;
		public int accountId { get; set; }

		public FriendDeleteRequestMessage(int accountId)
		{
			this.accountId = accountId;
		}

		public FriendDeleteRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(accountId);
		}

		public override void Deserialize(IDataReader reader)
		{
			accountId = reader.ReadInt();
		}

	}
}
