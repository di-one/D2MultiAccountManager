namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementObjective
	{
		public const short Id  = 4382;
		public virtual short TypeId => Id;
		public uint objectId { get; set; }
		public ushort maxValue { get; set; }

		public AchievementObjective(uint objectId, ushort maxValue)
		{
			this.objectId = objectId;
			this.maxValue = maxValue;
		}

		public AchievementObjective() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectId);
			writer.WriteVarUShort(maxValue);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUInt();
			maxValue = reader.ReadVarUShort();
		}

	}
}
