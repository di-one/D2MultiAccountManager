namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class Achievement
	{
		public const short Id  = 5905;
		public virtual short TypeId => Id;
		public ushort objectId { get; set; }
		public IEnumerable<AchievementObjective> finishedObjective { get; set; }
		public IEnumerable<AchievementStartedObjective> startedObjectives { get; set; }

		public Achievement(ushort objectId, IEnumerable<AchievementObjective> finishedObjective, IEnumerable<AchievementStartedObjective> startedObjectives)
		{
			this.objectId = objectId;
			this.finishedObjective = finishedObjective;
			this.startedObjectives = startedObjectives;
		}

		public Achievement() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objectId);
			writer.WriteShort((short)finishedObjective.Count());
			foreach (var objectToSend in finishedObjective)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)startedObjectives.Count());
			foreach (var objectToSend in startedObjectives)
            {
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUShort();
			var finishedObjectiveCount = reader.ReadUShort();
			var finishedObjective_ = new AchievementObjective[finishedObjectiveCount];
			for (var finishedObjectiveIndex = 0; finishedObjectiveIndex < finishedObjectiveCount; finishedObjectiveIndex++)
			{
				var objectToAdd = new AchievementObjective();
				objectToAdd.Deserialize(reader);
				finishedObjective_[finishedObjectiveIndex] = objectToAdd;
			}
			finishedObjective = finishedObjective_;
			var startedObjectivesCount = reader.ReadUShort();
			var startedObjectives_ = new AchievementStartedObjective[startedObjectivesCount];
			for (var startedObjectivesIndex = 0; startedObjectivesIndex < startedObjectivesCount; startedObjectivesIndex++)
			{
				var objectToAdd = new AchievementStartedObjective();
				objectToAdd.Deserialize(reader);
				startedObjectives_[startedObjectivesIndex] = objectToAdd;
			}
			startedObjectives = startedObjectives_;
		}

	}
}
