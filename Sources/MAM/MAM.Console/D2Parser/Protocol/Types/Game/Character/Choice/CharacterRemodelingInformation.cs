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
	public class CharacterRemodelingInformation : AbstractCharacterInformation
	{
		public new const short Id = 5581;
		public override short TypeId => Id;
		public string name { get; set; }
		public sbyte breed { get; set; }
		public bool sex { get; set; }
		public ushort cosmeticId { get; set; }
		public IEnumerable<int> colors { get; set; }

		public CharacterRemodelingInformation(ulong objectId, string name, sbyte breed, bool sex, ushort cosmeticId, IEnumerable<int> colors)
		{
			this.objectId = objectId;
			this.name = name;
			this.breed = breed;
			this.sex = sex;
			this.cosmeticId = cosmeticId;
			this.colors = colors;
		}

		public CharacterRemodelingInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
			writer.WriteSByte(breed);
			writer.WriteBoolean(sex);
			writer.WriteVarUShort(cosmeticId);
			writer.WriteShort((short)colors.Count());
			foreach (var objectToSend in colors)
            {
				writer.WriteInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
			breed = reader.ReadSByte();
			sex = reader.ReadBoolean();
			cosmeticId = reader.ReadVarUShort();
			var colorsCount = reader.ReadUShort();
			var colors_ = new int[colorsCount];
			for (var colorsIndex = 0; colorsIndex < colorsCount; colorsIndex++)
			{
				colors_[colorsIndex] = reader.ReadInt();
			}
			colors = colors_;
		}

	}
}
