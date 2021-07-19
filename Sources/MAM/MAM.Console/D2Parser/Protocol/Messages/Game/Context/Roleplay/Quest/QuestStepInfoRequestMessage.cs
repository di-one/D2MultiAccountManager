namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class QuestStepInfoRequestMessage : NetworkMessage
	{
		public const uint Id = 2999;
		public override uint MessageId => Id;
		public ushort questId { get; set; }

		public QuestStepInfoRequestMessage(ushort questId)
		{
			this.questId = questId;
		}

		public QuestStepInfoRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(questId);
		}

		public override void Deserialize(IDataReader reader)
		{
			questId = reader.ReadVarUShort();
		}

	}
}
