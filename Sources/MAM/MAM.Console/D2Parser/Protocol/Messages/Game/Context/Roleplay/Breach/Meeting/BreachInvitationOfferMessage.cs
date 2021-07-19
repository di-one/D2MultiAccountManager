namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachInvitationOfferMessage : NetworkMessage
	{
		public const uint Id = 6134;
		public override uint MessageId => Id;
		public CharacterMinimalInformations host { get; set; }
		public uint timeLeftBeforeCancel { get; set; }

		public BreachInvitationOfferMessage(CharacterMinimalInformations host, uint timeLeftBeforeCancel)
		{
			this.host = host;
			this.timeLeftBeforeCancel = timeLeftBeforeCancel;
		}

		public BreachInvitationOfferMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			host.Serialize(writer);
			writer.WriteVarUInt(timeLeftBeforeCancel);
		}

		public override void Deserialize(IDataReader reader)
		{
			host = new CharacterMinimalInformations();
			host.Deserialize(reader);
			timeLeftBeforeCancel = reader.ReadVarUInt();
		}

	}
}
