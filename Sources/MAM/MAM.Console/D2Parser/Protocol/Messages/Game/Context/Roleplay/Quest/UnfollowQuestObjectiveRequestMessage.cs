namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class UnfollowQuestObjectiveRequestMessage : NetworkMessage
	{
		public const uint Id = 1164;
		public override uint MessageId => Id;
		public ushort questId { get; set; }
		public short objectiveId { get; set; }

		public UnfollowQuestObjectiveRequestMessage(ushort questId, short objectiveId)
		{
			this.questId = questId;
			this.objectiveId = objectiveId;
		}

		public UnfollowQuestObjectiveRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(questId);
			writer.WriteShort(objectiveId);
		}

		public override void Deserialize(IDataReader reader)
		{
			questId = reader.ReadVarUShort();
			objectiveId = reader.ReadShort();
		}

	}
}
