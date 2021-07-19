namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SetEnableAVARequestMessage : NetworkMessage
	{
		public const uint Id = 9062;
		public override uint MessageId => Id;
		public bool enable { get; set; }

		public SetEnableAVARequestMessage(bool enable)
		{
			this.enable = enable;
		}

		public SetEnableAVARequestMessage() { }

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
