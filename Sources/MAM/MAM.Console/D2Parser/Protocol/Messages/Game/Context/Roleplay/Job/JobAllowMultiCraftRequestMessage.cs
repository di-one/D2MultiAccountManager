namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobAllowMultiCraftRequestMessage : NetworkMessage
	{
		public const uint Id = 7444;
		public override uint MessageId => Id;
		public bool enabled { get; set; }

		public JobAllowMultiCraftRequestMessage(bool enabled)
		{
			this.enabled = enabled;
		}

		public JobAllowMultiCraftRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(enabled);
		}

		public override void Deserialize(IDataReader reader)
		{
			enabled = reader.ReadBoolean();
		}

	}
}
