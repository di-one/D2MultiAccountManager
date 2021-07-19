namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterNameSuggestionSuccessMessage : NetworkMessage
	{
		public const uint Id = 4878;
		public override uint MessageId => Id;
		public string suggestion { get; set; }

		public CharacterNameSuggestionSuccessMessage(string suggestion)
		{
			this.suggestion = suggestion;
		}

		public CharacterNameSuggestionSuccessMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(suggestion);
		}

		public override void Deserialize(IDataReader reader)
		{
			suggestion = reader.ReadUTF();
		}

	}
}
