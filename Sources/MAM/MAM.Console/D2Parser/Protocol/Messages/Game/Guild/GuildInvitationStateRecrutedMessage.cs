namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInvitationStateRecrutedMessage : NetworkMessage
	{
		public const uint Id = 1335;
		public override uint MessageId => Id;
		public sbyte invitationState { get; set; }

		public GuildInvitationStateRecrutedMessage(sbyte invitationState)
		{
			this.invitationState = invitationState;
		}

		public GuildInvitationStateRecrutedMessage() { }

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
