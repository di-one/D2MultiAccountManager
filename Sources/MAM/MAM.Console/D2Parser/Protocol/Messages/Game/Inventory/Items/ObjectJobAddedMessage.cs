namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectJobAddedMessage : NetworkMessage
	{
		public const uint Id = 9804;
		public override uint MessageId => Id;
		public sbyte jobId { get; set; }

		public ObjectJobAddedMessage(sbyte jobId)
		{
			this.jobId = jobId;
		}

		public ObjectJobAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(jobId);
		}

		public override void Deserialize(IDataReader reader)
		{
			jobId = reader.ReadSByte();
		}

	}
}
