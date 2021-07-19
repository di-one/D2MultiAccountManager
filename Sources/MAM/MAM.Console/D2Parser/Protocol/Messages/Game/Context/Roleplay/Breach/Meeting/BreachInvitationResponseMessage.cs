namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachInvitationResponseMessage : NetworkMessage
	{
		public const uint Id = 9040;
		public override uint MessageId => Id;
		public CharacterMinimalInformations guest { get; set; }
		public bool accept { get; set; }

		public BreachInvitationResponseMessage(CharacterMinimalInformations guest, bool accept)
		{
			this.guest = guest;
			this.accept = accept;
		}

		public BreachInvitationResponseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			guest.Serialize(writer);
			writer.WriteBoolean(accept);
		}

		public override void Deserialize(IDataReader reader)
		{
			guest = new CharacterMinimalInformations();
			guest.Deserialize(reader);
			accept = reader.ReadBoolean();
		}

	}
}
