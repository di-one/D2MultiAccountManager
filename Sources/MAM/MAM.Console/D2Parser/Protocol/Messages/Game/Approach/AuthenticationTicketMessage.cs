namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AuthenticationTicketMessage : NetworkMessage
	{
		public const uint Id = 3920;
		public override uint MessageId => Id;
		public string lang { get; set; }
		public string ticket { get; set; }

		public AuthenticationTicketMessage(string lang, string ticket)
		{
			this.lang = lang;
			this.ticket = ticket;
		}

		public AuthenticationTicketMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(lang);
			writer.WriteUTF(ticket);
		}

		public override void Deserialize(IDataReader reader)
		{
			lang = reader.ReadUTF();
			ticket = reader.ReadUTF();
		}

	}
}
