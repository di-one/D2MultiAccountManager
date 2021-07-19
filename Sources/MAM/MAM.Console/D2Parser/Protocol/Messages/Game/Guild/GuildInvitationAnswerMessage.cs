namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInvitationAnswerMessage : NetworkMessage
	{
		public const uint Id = 3367;
		public override uint MessageId => Id;
		public bool accept { get; set; }

		public GuildInvitationAnswerMessage(bool accept)
		{
			this.accept = accept;
		}

		public GuildInvitationAnswerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(accept);
		}

		public override void Deserialize(IDataReader reader)
		{
			accept = reader.ReadBoolean();
		}

	}
}
