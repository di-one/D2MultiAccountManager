namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementRewardErrorMessage : NetworkMessage
	{
		public const uint Id = 8701;
		public override uint MessageId => Id;
		public short achievementId { get; set; }

		public AchievementRewardErrorMessage(short achievementId)
		{
			this.achievementId = achievementId;
		}

		public AchievementRewardErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(achievementId);
		}

		public override void Deserialize(IDataReader reader)
		{
			achievementId = reader.ReadShort();
		}

	}
}
