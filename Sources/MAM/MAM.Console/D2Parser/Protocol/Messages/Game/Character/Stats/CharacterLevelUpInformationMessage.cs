namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterLevelUpInformationMessage : CharacterLevelUpMessage
	{
		public new const uint Id = 8391;
		public override uint MessageId => Id;
		public string name { get; set; }
		public ulong objectId { get; set; }

		public CharacterLevelUpInformationMessage(ushort newLevel, string name, ulong objectId)
		{
			this.newLevel = newLevel;
			this.name = name;
			this.objectId = objectId;
		}

		public CharacterLevelUpInformationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
			writer.WriteVarULong(objectId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
			objectId = reader.ReadVarULong();
		}

	}
}
