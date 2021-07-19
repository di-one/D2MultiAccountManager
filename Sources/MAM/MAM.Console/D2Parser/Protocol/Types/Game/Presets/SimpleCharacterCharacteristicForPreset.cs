namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SimpleCharacterCharacteristicForPreset
	{
		public const short Id  = 8914;
		public virtual short TypeId => Id;
		public string keyword { get; set; }
		public short @base { get; set; }
		public short additionnal { get; set; }

		public SimpleCharacterCharacteristicForPreset(string keyword, short @base, short additionnal)
		{
			this.keyword = keyword;
			this.@base = @base;
			this.additionnal = additionnal;
		}

		public SimpleCharacterCharacteristicForPreset() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(keyword);
			writer.WriteVarShort(@base);
			writer.WriteVarShort(additionnal);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			keyword = reader.ReadUTF();
			@base = reader.ReadVarShort();
			additionnal = reader.ReadVarShort();
		}

	}
}
