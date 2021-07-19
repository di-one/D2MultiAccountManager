namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FriendWarnOnLevelGainStateMessage : NetworkMessage
	{
		public const uint Id = 1433;
		public override uint MessageId => Id;
		public bool enable { get; set; }

		public FriendWarnOnLevelGainStateMessage(bool enable)
		{
			this.enable = enable;
		}

		public FriendWarnOnLevelGainStateMessage() { }

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
