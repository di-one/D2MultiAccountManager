namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterCharacteristicForPreset : SimpleCharacterCharacteristicForPreset
	{
		public new const short Id = 7653;
		public override short TypeId => Id;
		public short stuff { get; set; }

		public CharacterCharacteristicForPreset(string keyword, short @base, short additionnal, short stuff)
		{
			this.keyword = keyword;
			this.@base = @base;
			this.additionnal = additionnal;
			this.stuff = stuff;
		}

		public CharacterCharacteristicForPreset() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarShort(stuff);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			stuff = reader.ReadVarShort();
		}

	}
}
