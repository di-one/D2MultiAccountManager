namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectUseOnCharacterMessage : ObjectUseMessage
	{
		public new const uint Id = 1132;
		public override uint MessageId => Id;
		public ulong characterId { get; set; }

		public ObjectUseOnCharacterMessage(uint objectUID, ulong characterId)
		{
			this.objectUID = objectUID;
			this.characterId = characterId;
		}

		public ObjectUseOnCharacterMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(characterId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			characterId = reader.ReadVarULong();
		}

	}
}
