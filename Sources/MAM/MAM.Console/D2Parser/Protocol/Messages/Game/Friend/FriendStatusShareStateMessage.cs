namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendStatusShareStateMessage : NetworkMessage
	{
		public const uint Id = 6126;
		public override uint MessageId => Id;
		public bool share { get; set; }

		public FriendStatusShareStateMessage(bool share)
		{
			this.share = share;
		}

		public FriendStatusShareStateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(share);
		}

		public override void Deserialize(IDataReader reader)
		{
			share = reader.ReadBoolean();
		}

	}
}
