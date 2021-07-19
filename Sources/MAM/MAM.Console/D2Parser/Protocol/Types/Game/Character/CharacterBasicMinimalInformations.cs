namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterBasicMinimalInformations : AbstractCharacterInformation
	{
		public new const short Id = 6835;
		public override short TypeId => Id;
		public string name { get; set; }

		public CharacterBasicMinimalInformations(ulong objectId, string name)
		{
			this.objectId = objectId;
			this.name = name;
		}

		public CharacterBasicMinimalInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
		}

	}
}
