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
	public class AchievementDetailedListMessage : NetworkMessage
	{
		public const uint Id = 8315;
		public override uint MessageId => Id;
		public IEnumerable<Achievement> startedAchievements { get; set; }
		public IEnumerable<Achievement> finishedAchievements { get; set; }

		public AchievementDetailedListMessage(IEnumerable<Achievement> startedAchievements, IEnumerable<Achievement> finishedAchievements)
		{
			this.startedAchievements = startedAchievements;
			this.finishedAchievements = finishedAchievements;
		}

		public AchievementDetailedListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)startedAchievements.Count());
			foreach (var objectToSend in startedAchievements)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)finishedAchievements.Count());
			foreach (var objectToSend in finishedAchievements)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var startedAchievementsCount = reader.ReadUShort();
			var startedAchievements_ = new Achievement[startedAchievementsCount];
			for (var startedAchievementsIndex = 0; startedAchievementsIndex < startedAchievementsCount; startedAchievementsIndex++)
			{
				var objectToAdd = new Achievement();
				objectToAdd.Deserialize(reader);
				startedAchievements_[startedAchievementsIndex] = objectToAdd;
			}
			startedAchievements = startedAchievements_;
			var finishedAchievementsCount = reader.ReadUShort();
			var finishedAchievements_ = new Achievement[finishedAchievementsCount];
			for (var finishedAchievementsIndex = 0; finishedAchievementsIndex < finishedAchievementsCount; finishedAchievementsIndex++)
			{
				var objectToAdd = new Achievement();
				objectToAdd.Deserialize(reader);
				finishedAchievements_[finishedAchievementsIndex] = objectToAdd;
			}
			finishedAchievements = finishedAchievements_;
		}

	}
}
