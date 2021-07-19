namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterDeletionRequestMessage : NetworkMessage
	{
		public const uint Id = 7637;
		public override uint MessageId => Id;
		public ulong characterId { get; set; }
		public string secretAnswerHash { get; set; }

		public CharacterDeletionRequestMessage(ulong characterId, string secretAnswerHash)
		{
			this.characterId = characterId;
			this.secretAnswerHash = secretAnswerHash;
		}

		public CharacterDeletionRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(characterId);
			writer.WriteUTF(secretAnswerHash);
		}

		public override void Deserialize(IDataReader reader)
		{
			characterId = reader.ReadVarULong();
			secretAnswerHash = reader.ReadUTF();
		}

	}
}
