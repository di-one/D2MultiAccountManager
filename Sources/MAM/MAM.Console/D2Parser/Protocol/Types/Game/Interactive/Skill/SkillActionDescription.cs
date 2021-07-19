namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SkillActionDescription
	{
		public const short Id  = 9402;
		public virtual short TypeId => Id;
		public ushort skillId { get; set; }

		public SkillActionDescription(ushort skillId)
		{
			this.skillId = skillId;
		}

		public SkillActionDescription() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(skillId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			skillId = reader.ReadVarUShort();
		}

	}
}
