namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementStartedObjective : AchievementObjective
	{
		public new const short Id = 6765;
		public override short TypeId => Id;
		public ushort value { get; set; }

		public AchievementStartedObjective(uint objectId, ushort maxValue, ushort value)
		{
			this.objectId = objectId;
			this.maxValue = maxValue;
			this.value = value;
		}

		public AchievementStartedObjective() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadVarUShort();
		}

	}
}
