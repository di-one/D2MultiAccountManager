namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobCrafterDirectoryListRequestMessage : NetworkMessage
	{
		public const uint Id = 6182;
		public override uint MessageId => Id;
		public sbyte jobId { get; set; }

		public JobCrafterDirectoryListRequestMessage(sbyte jobId)
		{
			this.jobId = jobId;
		}

		public JobCrafterDirectoryListRequestMessage() { }

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
