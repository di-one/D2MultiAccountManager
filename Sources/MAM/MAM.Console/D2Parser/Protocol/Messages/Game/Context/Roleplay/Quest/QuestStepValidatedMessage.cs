namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class QuestStepValidatedMessage : NetworkMessage
	{
		public const uint Id = 8401;
		public override uint MessageId => Id;
		public ushort questId { get; set; }
		public ushort stepId { get; set; }

		public QuestStepValidatedMessage(ushort questId, ushort stepId)
		{
			this.questId = questId;
			this.stepId = stepId;
		}

		public QuestStepValidatedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(questId);
			writer.WriteVarUShort(stepId);
		}

		public override void Deserialize(IDataReader reader)
		{
			questId = reader.ReadVarUShort();
			stepId = reader.ReadVarUShort();
		}

	}
}
