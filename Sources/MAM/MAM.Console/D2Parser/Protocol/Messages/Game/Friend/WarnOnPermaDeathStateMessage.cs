namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class WarnOnPermaDeathStateMessage : NetworkMessage
	{
		public const uint Id = 1798;
		public override uint MessageId => Id;
		public bool enable { get; set; }

		public WarnOnPermaDeathStateMessage(bool enable)
		{
			this.enable = enable;
		}

		public WarnOnPermaDeathStateMessage() { }

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
