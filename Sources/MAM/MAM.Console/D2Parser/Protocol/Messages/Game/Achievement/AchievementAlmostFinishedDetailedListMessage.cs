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
	public class AchievementAlmostFinishedDetailedListMessage : NetworkMessage
	{
		public const uint Id = 1599;
		public override uint MessageId => Id;
		public IEnumerable<Achievement> almostFinishedAchievements { get; set; }

		public AchievementAlmostFinishedDetailedListMessage(IEnumerable<Achievement> almostFinishedAchievements)
		{
			this.almostFinishedAchievements = almostFinishedAchievements;
		}

		public AchievementAlmostFinishedDetailedListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)almostFinishedAchievements.Count());
			foreach (var objectToSend in almostFinishedAchievements)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var almostFinishedAchievementsCount = reader.ReadUShort();
			var almostFinishedAchievements_ = new Achievement[almostFinishedAchievementsCount];
			for (var almostFinishedAchievementsIndex = 0; almostFinishedAchievementsIndex < almostFinishedAchievementsCount; almostFinishedAchievementsIndex++)
			{
				var objectToAdd = new Achievement();
				objectToAdd.Deserialize(reader);
				almostFinishedAchievements_[almostFinishedAchievementsIndex] = objectToAdd;
			}
			almostFinishedAchievements = almostFinishedAchievements_;
		}

	}
}
