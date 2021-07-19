namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InviteInHavenBagMessage : NetworkMessage
	{
		public const uint Id = 6969;
		public override uint MessageId => Id;
		public CharacterMinimalInformations guestInformations { get; set; }
		public bool accept { get; set; }

		public InviteInHavenBagMessage(CharacterMinimalInformations guestInformations, bool accept)
		{
			this.guestInformations = guestInformations;
			this.accept = accept;
		}

		public InviteInHavenBagMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			guestInformations.Serialize(writer);
			writer.WriteBoolean(accept);
		}

		public override void Deserialize(IDataReader reader)
		{
			guestInformations = new CharacterMinimalInformations();
			guestInformations.Deserialize(reader);
			accept = reader.ReadBoolean();
		}

	}
}
