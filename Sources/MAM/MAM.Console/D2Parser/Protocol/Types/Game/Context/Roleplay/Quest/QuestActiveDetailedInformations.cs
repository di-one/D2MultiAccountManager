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
	public class QuestActiveDetailedInformations : QuestActiveInformations
	{
		public new const short Id = 109;
		public override short TypeId => Id;
		public ushort stepId { get; set; }
		public IEnumerable<QuestObjectiveInformations> objectives { get; set; }

		public QuestActiveDetailedInformations(ushort questId, ushort stepId, IEnumerable<QuestObjectiveInformations> objectives)
		{
			this.questId = questId;
			this.stepId = stepId;
			this.objectives = objectives;
		}

		public QuestActiveDetailedInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(stepId);
			writer.WriteShort((short)objectives.Count());
			foreach (var objectToSend in objectives)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			stepId = reader.ReadVarUShort();
			var objectivesCount = reader.ReadUShort();
			var objectives_ = new QuestObjectiveInformations[objectivesCount];
			for (var objectivesIndex = 0; objectivesIndex < objectivesCount; objectivesIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<QuestObjectiveInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				objectives_[objectivesIndex] = objectToAdd;
			}
			objectives = objectives_;
		}

	}
}
