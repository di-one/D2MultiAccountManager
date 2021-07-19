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
	public class JobDescriptionMessage : NetworkMessage
	{
		public const uint Id = 1546;
		public override uint MessageId => Id;
		public IEnumerable<JobDescription> jobsDescription { get; set; }

		public JobDescriptionMessage(IEnumerable<JobDescription> jobsDescription)
		{
			this.jobsDescription = jobsDescription;
		}

		public JobDescriptionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)jobsDescription.Count());
			foreach (var objectToSend in jobsDescription)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var jobsDescriptionCount = reader.ReadUShort();
			var jobsDescription_ = new JobDescription[jobsDescriptionCount];
			for (var jobsDescriptionIndex = 0; jobsDescriptionIndex < jobsDescriptionCount; jobsDescriptionIndex++)
			{
				var objectToAdd = new JobDescription();
				objectToAdd.Deserialize(reader);
				jobsDescription_[jobsDescriptionIndex] = objectToAdd;
			}
			jobsDescription = jobsDescription_;
		}

	}
}
