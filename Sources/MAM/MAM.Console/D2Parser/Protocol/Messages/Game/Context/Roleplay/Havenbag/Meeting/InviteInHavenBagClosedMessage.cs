namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InviteInHavenBagClosedMessage : NetworkMessage
	{
		public const uint Id = 3874;
		public override uint MessageId => Id;
		public CharacterMinimalInformations hostInformations { get; set; }

		public InviteInHavenBagClosedMessage(CharacterMinimalInformations hostInformations)
		{
			this.hostInformations = hostInformations;
		}

		public InviteInHavenBagClosedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			hostInformations.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			hostInformations = new CharacterMinimalInformations();
			hostInformations.Deserialize(reader);
		}

	}
}
