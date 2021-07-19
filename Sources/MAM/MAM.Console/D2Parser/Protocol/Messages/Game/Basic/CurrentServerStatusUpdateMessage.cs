namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CurrentServerStatusUpdateMessage : NetworkMessage
	{
		public const uint Id = 144;
		public override uint MessageId => Id;
		public sbyte status { get; set; }

		public CurrentServerStatusUpdateMessage(sbyte status)
		{
			this.status = status;
		}

		public CurrentServerStatusUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(status);
		}

		public override void Deserialize(IDataReader reader)
		{
			status = reader.ReadSByte();
		}

	}
}
