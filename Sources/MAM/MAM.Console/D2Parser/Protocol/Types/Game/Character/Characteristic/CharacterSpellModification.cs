namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterSpellModification
	{
		public const short Id  = 5281;
		public virtual short TypeId => Id;
		public sbyte modificationType { get; set; }
		public ushort spellId { get; set; }
		public CharacterCharacteristicDetailed value { get; set; }

		public CharacterSpellModification(sbyte modificationType, ushort spellId, CharacterCharacteristicDetailed value)
		{
			this.modificationType = modificationType;
			this.spellId = spellId;
			this.value = value;
		}

		public CharacterSpellModification() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(modificationType);
			writer.WriteVarUShort(spellId);
			value.Serialize(writer);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			modificationType = reader.ReadSByte();
			spellId = reader.ReadVarUShort();
			value = new CharacterCharacteristicDetailed();
			value.Deserialize(reader);
		}

	}
}
