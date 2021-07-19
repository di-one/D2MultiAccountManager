namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InteractiveElementSkill
	{
		public const short Id  = 4345;
		public virtual short TypeId => Id;
		public uint skillId { get; set; }
		public int skillInstanceUid { get; set; }

		public InteractiveElementSkill(uint skillId, int skillInstanceUid)
		{
			this.skillId = skillId;
			this.skillInstanceUid = skillInstanceUid;
		}

		public InteractiveElementSkill() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(skillId);
			writer.WriteInt(skillInstanceUid);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			skillId = reader.ReadVarUInt();
			skillInstanceUid = reader.ReadInt();
		}

	}
}
