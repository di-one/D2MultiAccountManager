namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceInvitationStateRecrutedMessage : NetworkMessage
	{
		public const uint Id = 6214;
		public override uint MessageId => Id;
		public sbyte invitationState { get; set; }

		public AllianceInvitationStateRecrutedMessage(sbyte invitationState)
		{
			this.invitationState = invitationState;
		}

		public AllianceInvitationStateRecrutedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(invitationState);
		}

		public override void Deserialize(IDataReader reader)
		{
			invitationState = reader.ReadSByte();
		}

	}
}
