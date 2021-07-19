namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FollowedQuestsMessage : NetworkMessage
	{
		public const uint Id = 6209;
		public override uint MessageId => Id;
		public IEnumerable<QuestActiveDetailedInformations> quests { get; set; }

		public FollowedQuestsMessage(IEnumerable<QuestActiveDetailedInformations> quests)
		{
			this.quests = quests;
		}

		public FollowedQuestsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)quests.Count());
			foreach (var objectToSend in quests)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var questsCount = reader.ReadUShort();
			var quests_ = new QuestActiveDetailedInformations[questsCount];
			for (var questsIndex = 0; questsIndex < questsCount; questsIndex++)
			{
				var objectToAdd = new QuestActiveDetailedInformations();
				objectToAdd.Deserialize(reader);
				quests_[questsIndex] = objectToAdd;
			}
			quests = quests_;
		}

	}
}
