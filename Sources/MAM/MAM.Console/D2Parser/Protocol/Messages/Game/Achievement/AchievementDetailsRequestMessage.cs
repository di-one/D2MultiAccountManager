namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementDetailsRequestMessage : NetworkMessage
	{
		public const uint Id = 1347;
		public override uint MessageId => Id;
		public ushort achievementId { get; set; }

		public AchievementDetailsRequestMessage(ushort achievementId)
		{
			this.achievementId = achievementId;
		}

		public AchievementDetailsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(achievementId);
		}

		public override void Deserialize(IDataReader reader)
		{
			achievementId = reader.ReadVarUShort();
		}

	}
}
