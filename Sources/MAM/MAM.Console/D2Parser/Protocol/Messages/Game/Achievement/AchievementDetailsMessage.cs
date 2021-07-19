namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementDetailsMessage : NetworkMessage
	{
		public const uint Id = 6639;
		public override uint MessageId => Id;
		public Achievement achievement { get; set; }

		public AchievementDetailsMessage(Achievement achievement)
		{
			this.achievement = achievement;
		}

		public AchievementDetailsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			achievement.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			achievement = new Achievement();
			achievement.Deserialize(reader);
		}

	}
}
