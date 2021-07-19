namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendSetWarnOnLevelGainMessage : NetworkMessage
	{
		public const uint Id = 8465;
		public override uint MessageId => Id;
		public bool enable { get; set; }

		public FriendSetWarnOnLevelGainMessage(bool enable)
		{
			this.enable = enable;
		}

		public FriendSetWarnOnLevelGainMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(enable);
		}

		public override void Deserialize(IDataReader reader)
		{
			enable = reader.ReadBoolean();
		}

	}
}
