namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceInvitationStateRecruterMessage : NetworkMessage
	{
		public const uint Id = 6648;
		public override uint MessageId => Id;
		public string recrutedName { get; set; }
		public sbyte invitationState { get; set; }

		public AllianceInvitationStateRecruterMessage(string recrutedName, sbyte invitationState)
		{
			this.recrutedName = recrutedName;
			this.invitationState = invitationState;
		}

		public AllianceInvitationStateRecruterMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(recrutedName);
			writer.WriteSByte(invitationState);
		}

		public override void Deserialize(IDataReader reader)
		{
			recrutedName = reader.ReadUTF();
			invitationState = reader.ReadSByte();
		}

	}
}
