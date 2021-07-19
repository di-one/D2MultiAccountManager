namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterToRemodelInformations : CharacterRemodelingInformation
	{
		public new const short Id = 7780;
		public override short TypeId => Id;
		public sbyte possibleChangeMask { get; set; }
		public sbyte mandatoryChangeMask { get; set; }

		public CharacterToRemodelInformations(ulong objectId, string name, sbyte breed, bool sex, ushort cosmeticId, IEnumerable<int> colors, sbyte possibleChangeMask, sbyte mandatoryChangeMask)
		{
			this.objectId = objectId;
			this.name = name;
			this.breed = breed;
			this.sex = sex;
			this.cosmeticId = cosmeticId;
			this.colors = colors;
			this.possibleChangeMask = possibleChangeMask;
			this.mandatoryChangeMask = mandatoryChangeMask;
		}

		public CharacterToRemodelInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(possibleChangeMask);
			writer.WriteSByte(mandatoryChangeMask);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			possibleChangeMask = reader.ReadSByte();
			mandatoryChangeMask = reader.ReadSByte();
		}

	}
}
