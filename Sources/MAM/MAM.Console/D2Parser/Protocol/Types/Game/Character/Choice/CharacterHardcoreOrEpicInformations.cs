namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations
	{
		public new const short Id = 9632;
		public override short TypeId => Id;
		public sbyte deathState { get; set; }
		public ushort deathCount { get; set; }
		public ushort deathMaxLevel { get; set; }

		public CharacterHardcoreOrEpicInformations(ulong objectId, string name, ushort level, EntityLook entityLook, sbyte breed, bool sex, sbyte deathState, ushort deathCount, ushort deathMaxLevel)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.entityLook = entityLook;
			this.breed = breed;
			this.sex = sex;
			this.deathState = deathState;
			this.deathCount = deathCount;
			this.deathMaxLevel = deathMaxLevel;
		}

		public CharacterHardcoreOrEpicInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(deathState);
			writer.WriteVarUShort(deathCount);
			writer.WriteVarUShort(deathMaxLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			deathState = reader.ReadSByte();
			deathCount = reader.ReadVarUShort();
			deathMaxLevel = reader.ReadVarUShort();
		}

	}
}
