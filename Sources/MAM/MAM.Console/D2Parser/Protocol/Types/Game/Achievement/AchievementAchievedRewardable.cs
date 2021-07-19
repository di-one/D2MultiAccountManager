namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementAchievedRewardable : AchievementAchieved
	{
		public new const short Id = 676;
		public override short TypeId => Id;
		public ushort finishedlevel { get; set; }

		public AchievementAchievedRewardable(ushort objectId, ulong achievedBy, ushort finishedlevel)
		{
			this.objectId = objectId;
			this.achievedBy = achievedBy;
			this.finishedlevel = finishedlevel;
		}

		public AchievementAchievedRewardable() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(finishedlevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			finishedlevel = reader.ReadVarUShort();
		}

	}
}
