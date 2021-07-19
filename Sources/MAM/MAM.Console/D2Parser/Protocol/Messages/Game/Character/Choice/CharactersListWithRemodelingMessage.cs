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
	public class CharactersListWithRemodelingMessage : CharactersListMessage
	{
		public new const uint Id = 2685;
		public override uint MessageId => Id;
		public IEnumerable<CharacterToRemodelInformations> charactersToRemodel { get; set; }

		public CharactersListWithRemodelingMessage(IEnumerable<CharacterBaseInformations> characters, bool hasStartupActions, IEnumerable<CharacterToRemodelInformations> charactersToRemodel)
		{
			this.characters = characters;
			this.hasStartupActions = hasStartupActions;
			this.charactersToRemodel = charactersToRemodel;
		}

		public CharactersListWithRemodelingMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)charactersToRemodel.Count());
			foreach (var objectToSend in charactersToRemodel)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var charactersToRemodelCount = reader.ReadUShort();
			var charactersToRemodel_ = new CharacterToRemodelInformations[charactersToRemodelCount];
			for (var charactersToRemodelIndex = 0; charactersToRemodelIndex < charactersToRemodelCount; charactersToRemodelIndex++)
			{
				var objectToAdd = new CharacterToRemodelInformations();
				objectToAdd.Deserialize(reader);
				charactersToRemodel_[charactersToRemodelIndex] = objectToAdd;
			}
			charactersToRemodel = charactersToRemodel_;
		}

	}
}
