namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FollowQuestObjectiveRequestMessage : NetworkMessage
	{
		public const uint Id = 5287;
		public override uint MessageId => Id;
		public ushort questId { get; set; }
		public short objectiveId { get; set; }

		public FollowQuestObjectiveRequestMessage(ushort questId, short objectiveId)
		{
			this.questId = questId;
			this.objectiveId = objectiveId;
		}

		public FollowQuestObjectiveRequestMessage() { }

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
