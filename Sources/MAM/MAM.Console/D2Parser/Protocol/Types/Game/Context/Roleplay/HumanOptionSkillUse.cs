namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HumanOptionSkillUse : HumanOption
	{
		public new const short Id = 1691;
		public override short TypeId => Id;
		public uint elementId { get; set; }
		public ushort skillId { get; set; }
		public double skillEndTime { get; set; }

		public HumanOptionSkillUse(uint elementId, ushort skillId, double skillEndTime)
		{
			this.elementId = elementId;
			this.skillId = skillId;
			this.skillEndTime = skillEndTime;
		}

		public HumanOptionSkillUse() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(elementId);
			writer.WriteVarUShort(skillId);
			writer.WriteDouble(skillEndTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			elementId = reader.ReadVarUInt();
			skillId = reader.ReadVarUShort();
			skillEndTime = reader.ReadDouble();
		}

	}
}
