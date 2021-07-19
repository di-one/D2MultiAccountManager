namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterReplayRequestMessage : NetworkMessage
	{
		public const uint Id = 9534;
		public override uint MessageId => Id;
		public ulong characterId { get; set; }

		public CharacterReplayRequestMessage(ulong characterId)
		{
			this.characterId = characterId;
		}

		public CharacterReplayRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(characterId);
		}

		public override void Deserialize(IDataReader reader)
		{
			characterId = reader.ReadVarULong();
		}

	}
}
