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
	public class CharactersListMessage : BasicCharactersListMessage
	{
		public new const uint Id = 7692;
		public override uint MessageId => Id;
		public bool hasStartupActions { get; set; }

		public CharactersListMessage(IEnumerable<CharacterBaseInformations> characters, bool hasStartupActions)
		{
			this.characters = characters;
			this.hasStartupActions = hasStartupActions;
		}

		public CharactersListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(hasStartupActions);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			hasStartupActions = reader.ReadBoolean();
		}

	}
}
