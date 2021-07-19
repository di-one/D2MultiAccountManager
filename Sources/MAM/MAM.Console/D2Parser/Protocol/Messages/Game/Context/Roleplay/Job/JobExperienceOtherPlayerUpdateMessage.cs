namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobExperienceOtherPlayerUpdateMessage : JobExperienceUpdateMessage
	{
		public new const uint Id = 4536;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }

		public JobExperienceOtherPlayerUpdateMessage(JobExperience experiencesUpdate, ulong playerId)
		{
			this.experiencesUpdate = experiencesUpdate;
			this.playerId = playerId;
		}

		public JobExperienceOtherPlayerUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(playerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerId = reader.ReadVarULong();
		}

	}
}
