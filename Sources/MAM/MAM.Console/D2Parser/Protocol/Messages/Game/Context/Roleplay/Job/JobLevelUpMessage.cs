namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobLevelUpMessage : NetworkMessage
	{
		public const uint Id = 5198;
		public override uint MessageId => Id;
		public byte newLevel { get; set; }
		public JobDescription jobsDescription { get; set; }

		public JobLevelUpMessage(byte newLevel, JobDescription jobsDescription)
		{
			this.newLevel = newLevel;
			this.jobsDescription = jobsDescription;
		}

		public JobLevelUpMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteByte(newLevel);
			jobsDescription.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			newLevel = reader.ReadByte();
			jobsDescription = new JobDescription();
			jobsDescription.Deserialize(reader);
		}

	}
}
