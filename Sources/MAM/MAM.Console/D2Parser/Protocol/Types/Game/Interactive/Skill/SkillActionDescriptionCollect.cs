namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SkillActionDescriptionCollect : SkillActionDescriptionTimed
	{
		public new const short Id = 9547;
		public override short TypeId => Id;
		public ushort min { get; set; }
		public ushort max { get; set; }

		public SkillActionDescriptionCollect(ushort skillId, byte time, ushort min, ushort max)
		{
			this.skillId = skillId;
			this.time = time;
			this.min = min;
			this.max = max;
		}

		public SkillActionDescriptionCollect() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(min);
			writer.WriteVarUShort(max);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			min = reader.ReadVarUShort();
			max = reader.ReadVarUShort();
		}

	}
}
