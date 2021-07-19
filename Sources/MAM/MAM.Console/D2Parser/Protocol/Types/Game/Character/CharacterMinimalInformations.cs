namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterMinimalInformations : CharacterBasicMinimalInformations
	{
		public new const short Id = 2126;
		public override short TypeId => Id;
		public ushort level { get; set; }

		public CharacterMinimalInformations(ulong objectId, string name, ushort level)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
		}

		public CharacterMinimalInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(level);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			level = reader.ReadVarUShort();
		}

	}
}
