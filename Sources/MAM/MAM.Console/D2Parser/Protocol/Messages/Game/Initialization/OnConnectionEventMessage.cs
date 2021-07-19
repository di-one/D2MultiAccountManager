namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class OnConnectionEventMessage : NetworkMessage
	{
		public const uint Id = 5599;
		public override uint MessageId => Id;
		public sbyte eventType { get; set; }

		public OnConnectionEventMessage(sbyte eventType)
		{
			this.eventType = eventType;
		}

		public OnConnectionEventMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(eventType);
		}

		public override void Deserialize(IDataReader reader)
		{
			eventType = reader.ReadSByte();
		}

	}
}
