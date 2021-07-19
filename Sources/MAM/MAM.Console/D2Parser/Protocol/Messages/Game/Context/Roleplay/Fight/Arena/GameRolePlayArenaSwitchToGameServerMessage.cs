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
	public class GameRolePlayArenaSwitchToGameServerMessage : NetworkMessage
	{
		public const uint Id = 4630;
		public override uint MessageId => Id;
		public bool validToken { get; set; }
		public IEnumerable<sbyte> ticket { get; set; }
		public short homeServerId { get; set; }

		public GameRolePlayArenaSwitchToGameServerMessage(bool validToken, IEnumerable<sbyte> ticket, short homeServerId)
		{
			this.validToken = validToken;
			this.ticket = ticket;
			this.homeServerId = homeServerId;
		}

		public GameRolePlayArenaSwitchToGameServerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(validToken);
			writer.WriteVarInt(ticket.Count());
			foreach (var objectToSend in ticket)
            {
				writer.WriteSByte(objectToSend);
			}
			writer.WriteShort(homeServerId);
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
			homeServerId = reader.ReadShort();
		}

	}
}
