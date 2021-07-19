namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementAchieved
	{
		public const short Id  = 8790;
		public virtual short TypeId => Id;
		public ushort objectId { get; set; }
		public ulong achievedBy { get; set; }

		public AchievementAchieved(ushort objectId, ulong achievedBy)
		{
			this.objectId = objectId;
			this.achievedBy = achievedBy;
		}

		public AchievementAchieved() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objectId);
			writer.WriteVarULong(achievedBy);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUShort();
			achievedBy = reader.ReadVarULong();
		}

	}
}
