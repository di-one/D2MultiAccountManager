namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InteractiveElementWithAgeBonus : InteractiveElement
	{
		public new const short Id = 7651;
		public override short TypeId => Id;
		public short ageBonus { get; set; }

		public InteractiveElementWithAgeBonus(int elementId, int elementTypeId, IEnumerable<InteractiveElementSkill> enabledSkills, IEnumerable<InteractiveElementSkill> disabledSkills, bool onCurrentMap, short ageBonus)
		{
			this.elementId = elementId;
			this.elementTypeId = elementTypeId;
			this.enabledSkills = enabledSkills;
			this.disabledSkills = disabledSkills;
			this.onCurrentMap = onCurrentMap;
			this.ageBonus = ageBonus;
		}

		public InteractiveElementWithAgeBonus() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(ageBonus);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			ageBonus = reader.ReadShort();
		}

	}
}
