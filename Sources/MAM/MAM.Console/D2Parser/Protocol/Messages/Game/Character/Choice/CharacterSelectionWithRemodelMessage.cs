namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterSelectionWithRemodelMessage : CharacterSelectionMessage
	{
		public new const uint Id = 1490;
		public override uint MessageId => Id;
		public RemodelingInformation remodel { get; set; }

		public CharacterSelectionWithRemodelMessage(ulong objectId, RemodelingInformation remodel)
		{
			this.objectId = objectId;
			this.remodel = remodel;
		}

		public CharacterSelectionWithRemodelMessage() { }

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
