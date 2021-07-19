namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class QuestObjectiveValidationMessage : NetworkMessage
	{
		public const uint Id = 3382;
		public override uint MessageId => Id;
		public ushort questId { get; set; }
		public ushort objectiveId { get; set; }

		public QuestObjectiveValidationMessage(ushort questId, ushort objectiveId)
		{
			this.questId = questId;
			this.objectiveId = objectiveId;
		}

		public QuestObjectiveValidationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(questId);
			writer.WriteVarUShort(objectiveId);
		}

		public override void Deserialize(IDataReader reader)
		{
			questId = reader.ReadVarUShort();
			objectiveId = reader.ReadVarUShort();
		}

	}
}
