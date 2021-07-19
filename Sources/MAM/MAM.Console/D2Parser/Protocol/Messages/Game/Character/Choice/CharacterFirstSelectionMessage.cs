namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterFirstSelectionMessage : CharacterSelectionMessage
	{
		public new const uint Id = 8029;
		public override uint MessageId => Id;
		public bool doTutorial { get; set; }

		public CharacterFirstSelectionMessage(ulong objectId, bool doTutorial)
		{
			this.objectId = objectId;
			this.doTutorial = doTutorial;
		}

		public CharacterFirstSelectionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(doTutorial);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			doTutorial = reader.ReadBoolean();
		}

	}
}
