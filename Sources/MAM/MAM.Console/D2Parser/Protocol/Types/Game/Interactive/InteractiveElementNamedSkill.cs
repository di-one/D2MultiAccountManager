namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InteractiveElementNamedSkill : InteractiveElementSkill
	{
		public new const short Id = 8215;
		public override short TypeId => Id;
		public uint nameId { get; set; }

		public InteractiveElementNamedSkill(uint skillId, int skillInstanceUid, uint nameId)
		{
			this.skillId = skillId;
			this.skillInstanceUid = skillInstanceUid;
			this.nameId = nameId;
		}

		public InteractiveElementNamedSkill() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(nameId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			nameId = reader.ReadVarUInt();
		}

	}
}
