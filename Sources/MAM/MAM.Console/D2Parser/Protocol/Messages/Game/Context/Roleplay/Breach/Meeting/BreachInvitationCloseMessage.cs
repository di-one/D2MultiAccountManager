namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachInvitationCloseMessage : NetworkMessage
	{
		public const uint Id = 8320;
		public override uint MessageId => Id;
		public CharacterMinimalInformations host { get; set; }

		public BreachInvitationCloseMessage(CharacterMinimalInformations host)
		{
			this.host = host;
		}

		public BreachInvitationCloseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			host.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			host = new CharacterMinimalInformations();
			host.Deserialize(reader);
		}

	}
}
