namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
	{
		public new const short Id = 1956;
		public override short TypeId => Id;
		public EntityLook entityLook { get; set; }
		public sbyte breed { get; set; }

		public CharacterMinimalPlusLookInformations(ulong objectId, string name, ushort level, EntityLook entityLook, sbyte breed)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.entityLook = entityLook;
			this.breed = breed;
		}

		public CharacterMinimalPlusLookInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			entityLook.Serialize(writer);
			writer.WriteSByte(breed);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			entityLook = new EntityLook();
			entityLook.Deserialize(reader);
			breed = reader.ReadSByte();
		}

	}
}
