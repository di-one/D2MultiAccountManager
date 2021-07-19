namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobBookSubscribeRequestMessage : NetworkMessage
	{
		public const uint Id = 5290;
		public override uint MessageId => Id;
		public IEnumerable<byte> jobIds { get; set; }

		public JobBookSubscribeRequestMessage(IEnumerable<byte> jobIds)
		{
			this.jobIds = jobIds;
		}

		public JobBookSubscribeRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)jobIds.Count());
			foreach (var objectToSend in jobIds)
            {
				writer.WriteByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var jobIdsCount = reader.ReadUShort();
			var jobIds_ = new byte[jobIdsCount];
			for (var jobIdsIndex = 0; jobIdsIndex < jobIdsCount; jobIdsIndex++)
			{
				jobIds_[jobIdsIndex] = reader.ReadByte();
			}
			jobIds = jobIds_;
		}

	}
}
