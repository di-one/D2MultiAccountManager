namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SpawnCharacterInformation : SpawnInformation
	{
		public new const short Id = 5438;
		public override short TypeId => Id;
		public string name { get; set; }
		public ushort level { get; set; }

		public SpawnCharacterInformation(string name, ushort level)
		{
			this.name = name;
			this.level = level;
		}

		public SpawnCharacterInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
			writer.WriteVarUShort(level);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
			level = reader.ReadVarUShort();
		}

	}
}
