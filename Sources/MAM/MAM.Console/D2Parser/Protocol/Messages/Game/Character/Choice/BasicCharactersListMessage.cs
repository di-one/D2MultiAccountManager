namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicCharactersListMessage : NetworkMessage
	{
		public const uint Id = 6379;
		public override uint MessageId => Id;
		public IEnumerable<CharacterBaseInformations> characters { get; set; }

		public BasicCharactersListMessage(IEnumerable<CharacterBaseInformations> characters)
		{
			this.characters = characters;
		}

		public BasicCharactersListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)characters.Count());
			foreach (var objectToSend in characters)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var charactersCount = reader.ReadUShort();
			var characters_ = new CharacterBaseInformations[charactersCount];
			for (var charactersIndex = 0; charactersIndex < charactersCount; charactersIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<CharacterBaseInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				characters_[charactersIndex] = objectToAdd;
			}
			characters = characters_;
		}

	}
}
