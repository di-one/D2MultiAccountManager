namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterMinimalGuildPublicInformations : CharacterMinimalInformations
	{
		public new const short Id = 5512;
		public override short TypeId => Id;
		public uint rank { get; set; }

		public CharacterMinimalGuildPublicInformations(ulong objectId, string name, ushort level, uint rank)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
			this.rank = rank;
		}

		public CharacterMinimalGuildPublicInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(rank);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			rank = reader.ReadVarUInt();
		}

	}
}
