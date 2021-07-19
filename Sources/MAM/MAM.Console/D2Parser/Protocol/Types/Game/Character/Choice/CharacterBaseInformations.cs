namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
	{
		public new const short Id = 7196;
		public override short TypeId => Id;
		public bool sex { get; set; }

		public CharacterBaseInformations(ulong objectId, string name, ushort level, EntityLook entityLook, sbyte breed, bool sex)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.entityLook = entityLook;
			this.breed = breed;
			this.sex = sex;
		}

		public CharacterBaseInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(sex);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			sex = reader.ReadBoolean();
		}

	}
}
