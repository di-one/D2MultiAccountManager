namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChannelEnablingChangeMessage : NetworkMessage
	{
		public const uint Id = 3156;
		public override uint MessageId => Id;
		public sbyte channel { get; set; }
		public bool enable { get; set; }

		public ChannelEnablingChangeMessage(sbyte channel, bool enable)
		{
			this.channel = channel;
			this.enable = enable;
		}

		public ChannelEnablingChangeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(channel);
			writer.WriteBoolean(enable);
		}

		public override void Deserialize(IDataReader reader)
		{
			channel = reader.ReadSByte();
			enable = reader.ReadBoolean();
		}

	}
}
