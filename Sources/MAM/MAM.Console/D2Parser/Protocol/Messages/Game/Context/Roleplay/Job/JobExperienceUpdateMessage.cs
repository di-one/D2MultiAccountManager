namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobExperienceUpdateMessage : NetworkMessage
	{
		public const uint Id = 8784;
		public override uint MessageId => Id;
		public JobExperience experiencesUpdate { get; set; }

		public JobExperienceUpdateMessage(JobExperience experiencesUpdate)
		{
			this.experiencesUpdate = experiencesUpdate;
		}

		public JobExperienceUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			experiencesUpdate.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			experiencesUpdate = new JobExperience();
			experiencesUpdate.Deserialize(reader);
		}

	}
}
