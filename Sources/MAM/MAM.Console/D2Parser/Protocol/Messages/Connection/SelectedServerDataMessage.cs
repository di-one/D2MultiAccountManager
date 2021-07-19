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
	public class SelectedServerDataMessage : NetworkMessage
	{
		public const uint Id = 1568;
		public override uint MessageId => Id;
		public ushort serverId { get; set; }
		public string address { get; set; }
		public IEnumerable<ushort> ports { get; set; }
		public bool canCreateNewCharacter { get; set; }
		public IEnumerable<sbyte> ticket { get; set; }

		public SelectedServerDataMessage(ushort serverId, string address, IEnumerable<ushort> ports, bool canCreateNewCharacter, IEnumerable<sbyte> ticket)
		{
			this.serverId = serverId;
			this.address = address;
			this.ports = ports;
			this.canCreateNewCharacter = canCreateNewCharacter;
			this.ticket = ticket;
		}

		public SelectedServerDataMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(serverId);
			writer.WriteUTF(address);
			writer.WriteShort((short)ports.Count());
			foreach (var objectToSend in ports)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteBoolean(canCreateNewCharacter);
			writer.WriteVarInt(ticket.Count());
			foreach (var objectToSend in ticket)
            {
				writer.WriteSByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			serverId = reader.ReadVarUShort();
			address = reader.ReadUTF();
			var portsCount = reader.ReadUShort();
			var ports_ = new ushort[portsCount];
			for (var portsIndex = 0; portsIndex < portsCount; portsIndex++)
			{
				ports_[portsIndex] = reader.ReadVarUShort();
			}
			ports = ports_;
			canCreateNewCharacter = reader.ReadBoolean();
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
