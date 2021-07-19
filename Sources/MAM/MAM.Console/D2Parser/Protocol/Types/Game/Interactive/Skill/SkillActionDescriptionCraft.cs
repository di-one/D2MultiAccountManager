namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SkillActionDescriptionCraft : SkillActionDescription
	{
		public new const short Id = 4065;
		public override short TypeId => Id;
		public sbyte probability { get; set; }

		public SkillActionDescriptionCraft(ushort skillId, sbyte probability)
		{
			this.skillId = skillId;
			this.probability = probability;
		}

		public SkillActionDescriptionCraft() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(probability);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			probability = reader.ReadSByte();
		}

	}
}
