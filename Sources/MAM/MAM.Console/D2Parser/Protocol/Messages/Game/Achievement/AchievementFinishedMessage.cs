namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementFinishedMessage : NetworkMessage
	{
		public const uint Id = 7456;
		public override uint MessageId => Id;
		public AchievementAchievedRewardable achievement { get; set; }

		public AchievementFinishedMessage(AchievementAchievedRewardable achievement)
		{
			this.achievement = achievement;
		}

		public AchievementFinishedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			achievement.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			achievement = new AchievementAchievedRewardable();
			achievement.Deserialize(reader);
		}

	}
}
