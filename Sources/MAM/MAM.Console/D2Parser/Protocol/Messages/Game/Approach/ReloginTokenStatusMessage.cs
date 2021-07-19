namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ReloginTokenStatusMessage : NetworkMessage
	{
		public const uint Id = 6122;
		public override uint MessageId => Id;
		public bool validToken { get; set; }
		public IEnumerable<sbyte> ticket { get; set; }

		public ReloginTokenStatusMessage(bool validToken, IEnumerable<sbyte> ticket)
		{
			this.validToken = validToken;
			this.ticket = ticket;
		}

		public ReloginTokenStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(validToken);
			writer.WriteVarInt(ticket.Count());
			foreach (var objectToSend in ticket)
            {
				writer.WriteSByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			validToken = reader.ReadBoolean();
			var ticketCount = reader.ReadVarInt();
			var ticket_ = new sbyte[ticketCount];
			for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++)
			{
				ticket_[ticketIndex] = reader.ReadSByte();
			}
			ticket = ticket_;
		}

	}
}
