namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class QuestValidatedMessage : NetworkMessage
	{
		public const uint Id = 8020;
		public override uint MessageId => Id;
		public ushort questId { get; set; }

		public QuestValidatedMessage(ushort questId)
		{
			this.questId = questId;
		}

		public QuestValidatedMessage() { }

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
