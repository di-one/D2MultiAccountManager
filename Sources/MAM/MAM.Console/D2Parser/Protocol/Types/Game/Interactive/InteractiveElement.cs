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
	public class InteractiveElement
	{
		public const short Id  = 8429;
		public virtual short TypeId => Id;
		public int elementId { get; set; }
		public int elementTypeId { get; set; }
		public IEnumerable<InteractiveElementSkill> enabledSkills { get; set; }
		public IEnumerable<InteractiveElementSkill> disabledSkills { get; set; }
		public bool onCurrentMap { get; set; }

		public InteractiveElement(int elementId, int elementTypeId, IEnumerable<InteractiveElementSkill> enabledSkills, IEnumerable<InteractiveElementSkill> disabledSkills, bool onCurrentMap)
		{
			this.elementId = elementId;
			this.elementTypeId = elementTypeId;
			this.enabledSkills = enabledSkills;
			this.disabledSkills = disabledSkills;
			this.onCurrentMap = onCurrentMap;
		}

		public InteractiveElement() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(elementId);
			writer.WriteInt(elementTypeId);
			writer.WriteShort((short)enabledSkills.Count());
			foreach (var objectToSend in enabledSkills)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)disabledSkills.Count());
			foreach (var objectToSend in disabledSkills)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteBoolean(onCurrentMap);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			elementId = reader.ReadInt();
			elementTypeId = reader.ReadInt();
			var enabledSkillsCount = reader.ReadUShort();
			var enabledSkills_ = new InteractiveElementSkill[enabledSkillsCount];
			for (var enabledSkillsIndex = 0; enabledSkillsIndex < enabledSkillsCount; enabledSkillsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				enabledSkills_[enabledSkillsIndex] = objectToAdd;
			}
			enabledSkills = enabledSkills_;
			var disabledSkillsCount = reader.ReadUShort();
			var disabledSkills_ = new InteractiveElementSkill[disabledSkillsCount];
			for (var disabledSkillsIndex = 0; disabledSkillsIndex < disabledSkillsCount; disabledSkillsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				disabledSkills_[disabledSkillsIndex] = objectToAdd;
			}
			disabledSkills = disabledSkills_;
			onCurrentMap = reader.ReadBoolean();
		}

	}
}
