namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterReplayWithRemodelRequestMessage : CharacterReplayRequestMessage
	{
		public new const uint Id = 3996;
		public override uint MessageId => Id;
		public RemodelingInformation remodel { get; set; }

		public CharacterReplayWithRemodelRequestMessage(ulong characterId, RemodelingInformation remodel)
		{
			this.characterId = characterId;
			this.remodel = remodel;
		}

		public CharacterReplayWithRemodelRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			remodel.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			remodel = new RemodelingInformation();
			remodel.Deserialize(reader);
		}

	}
}
