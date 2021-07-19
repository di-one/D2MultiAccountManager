namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SkillActionDescriptionTimed : SkillActionDescription
	{
		public new const short Id = 4668;
		public override short TypeId => Id;
		public byte time { get; set; }

		public SkillActionDescriptionTimed(ushort skillId, byte time)
		{
			this.skillId = skillId;
			this.time = time;
		}

		public SkillActionDescriptionTimed() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteByte(time);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			time = reader.ReadByte();
		}

	}
}
