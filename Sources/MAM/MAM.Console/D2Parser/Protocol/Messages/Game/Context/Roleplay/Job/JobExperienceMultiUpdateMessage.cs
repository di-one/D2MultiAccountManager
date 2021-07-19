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
	public class JobExperienceMultiUpdateMessage : NetworkMessage
	{
		public const uint Id = 5307;
		public override uint MessageId => Id;
		public IEnumerable<JobExperience> experiencesUpdate { get; set; }

		public JobExperienceMultiUpdateMessage(IEnumerable<JobExperience> experiencesUpdate)
		{
			this.experiencesUpdate = experiencesUpdate;
		}

		public JobExperienceMultiUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)experiencesUpdate.Count());
			foreach (var objectToSend in experiencesUpdate)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var experiencesUpdateCount = reader.ReadUShort();
			var experiencesUpdate_ = new JobExperience[experiencesUpdateCount];
			for (var experiencesUpdateIndex = 0; experiencesUpdateIndex < experiencesUpdateCount; experiencesUpdateIndex++)
			{
				var objectToAdd = new JobExperience();
				objectToAdd.Deserialize(reader);
				experiencesUpdate_[experiencesUpdateIndex] = objectToAdd;
			}
			experiencesUpdate = experiencesUpdate_;
		}

	}
}
