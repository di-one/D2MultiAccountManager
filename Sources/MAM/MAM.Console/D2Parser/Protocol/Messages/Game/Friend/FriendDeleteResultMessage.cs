namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendDeleteResultMessage : NetworkMessage
	{
		public const uint Id = 7198;
		public override uint MessageId => Id;
		public bool success { get; set; }
		public AccountTagInformation tag { get; set; }

		public FriendDeleteResultMessage(bool success, AccountTagInformation tag)
		{
			this.success = success;
			this.tag = tag;
		}

		public FriendDeleteResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(success);
			tag.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			success = reader.ReadBoolean();
			tag = new AccountTagInformation();
			tag.Deserialize(reader);
		}

	}
}
