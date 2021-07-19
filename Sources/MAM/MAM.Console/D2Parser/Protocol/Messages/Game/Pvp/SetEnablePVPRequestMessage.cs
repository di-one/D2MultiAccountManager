namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SetEnablePVPRequestMessage : NetworkMessage
	{
		public const uint Id = 3481;
		public override uint MessageId => Id;
		public bool enable { get; set; }

		public SetEnablePVPRequestMessage(bool enable)
		{
			this.enable = enable;
		}

		public SetEnablePVPRequestMessage() { }

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
