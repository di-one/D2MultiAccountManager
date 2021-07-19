namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Protocol.Enums;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterCreationRequestMessage : NetworkMessage
	{
		public const uint Id = 9213;
		public override uint MessageId => Id;
		public string name { get; set; }
		public sbyte breed { get; set; }
		public bool sex { get; set; }
		public ushort cosmeticId { get; set; }

		public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, ushort cosmeticId)
		{
			this.name = name;
			this.breed = breed;
			this.sex = sex;
			this.cosmeticId = cosmeticId;
		}

		public CharacterCreationRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(name);
			writer.WriteSByte(breed);
			writer.WriteBoolean(sex);
			writer.WriteVarUShort(cosmeticId);
		}

		public override void Deserialize(IDataReader reader)
		{
			name = reader.ReadUTF();
			breed = reader.ReadSByte();
			sex = reader.ReadBoolean();
			cosmeticId = reader.ReadVarUShort();
		}

	}
}
