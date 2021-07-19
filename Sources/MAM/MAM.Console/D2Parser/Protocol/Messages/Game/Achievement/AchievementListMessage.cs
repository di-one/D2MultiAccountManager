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
	public class AchievementListMessage : NetworkMessage
	{
		public const uint Id = 9654;
		public override uint MessageId => Id;
		public IEnumerable<AchievementAchieved> finishedAchievements { get; set; }

		public AchievementListMessage(IEnumerable<AchievementAchieved> finishedAchievements)
		{
			this.finishedAchievements = finishedAchievements;
		}

		public AchievementListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)finishedAchievements.Count());
			foreach (var objectToSend in finishedAchievements)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var finishedAchievementsCount = reader.ReadUShort();
			var finishedAchievements_ = new AchievementAchieved[finishedAchievementsCount];
			for (var finishedAchievementsIndex = 0; finishedAchievementsIndex < finishedAchievementsCount; finishedAchievementsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<AchievementAchieved>((ushort)reader.ReadShort());
				objectToAdd.Deserialize(reader);
				finishedAchievements_[finishedAchievementsIndex] = objectToAdd;
			}
			finishedAchievements = finishedAchievements_;
		}

	}
}
