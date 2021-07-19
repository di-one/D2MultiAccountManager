namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InviteInHavenBagOfferMessage : NetworkMessage
	{
		public const uint Id = 1731;
		public override uint MessageId => Id;
		public CharacterMinimalInformations hostInformations { get; set; }
		public int timeLeftBeforeCancel { get; set; }

		public InviteInHavenBagOfferMessage(CharacterMinimalInformations hostInformations, int timeLeftBeforeCancel)
		{
			this.hostInformations = hostInformations;
			this.timeLeftBeforeCancel = timeLeftBeforeCancel;
		}

		public InviteInHavenBagOfferMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			hostInformations.Serialize(writer);
			writer.WriteVarInt(timeLeftBeforeCancel);
		}

		public override void Deserialize(IDataReader reader)
		{
			hostInformations = new CharacterMinimalInformations();
			hostInformations.Deserialize(reader);
			timeLeftBeforeCancel = reader.ReadVarInt();
		}

	}
}
