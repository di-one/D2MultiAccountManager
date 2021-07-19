namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
	{
		public new const short Id = 889;
		public override short TypeId => Id;
		public uint grade { get; set; }

		public CharacterMinimalPlusLookAndGradeInformations(ulong objectId, string name, ushort level, EntityLook entityLook, sbyte breed, uint grade)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.entityLook = entityLook;
			this.breed = breed;
			this.grade = grade;
		}

		public CharacterMinimalPlusLookAndGradeInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(grade);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			grade = reader.ReadVarUInt();
		}

	}
}
