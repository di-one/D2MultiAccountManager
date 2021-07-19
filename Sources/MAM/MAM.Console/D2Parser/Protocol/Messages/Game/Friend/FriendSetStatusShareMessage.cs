namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendSetStatusShareMessage : NetworkMessage
	{
		public const uint Id = 9325;
		public override uint MessageId => Id;
		public bool share { get; set; }

		public FriendSetStatusShareMessage(bool share)
		{
			this.share = share;
		}

		public FriendSetStatusShareMessage() { }

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
