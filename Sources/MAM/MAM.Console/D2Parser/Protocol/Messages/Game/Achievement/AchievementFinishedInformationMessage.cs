namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementFinishedInformationMessage : AchievementFinishedMessage
	{
		public new const uint Id = 6462;
		public override uint MessageId => Id;
		public string name { get; set; }
		public ulong playerId { get; set; }

		public AchievementFinishedInformationMessage(AchievementAchievedRewardable achievement, string name, ulong playerId)
		{
			this.achievement = achievement;
			this.name = name;
			this.playerId = playerId;
		}

		public AchievementFinishedInformationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
			writer.WriteVarULong(playerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
			playerId = reader.ReadVarULong();
		}

	}
}
