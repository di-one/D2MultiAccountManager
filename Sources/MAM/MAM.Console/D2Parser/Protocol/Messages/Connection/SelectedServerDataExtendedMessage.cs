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
	public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
	{
		public new const uint Id = 900;
		public override uint MessageId => Id;
		public IEnumerable<GameServerInformations> servers { get; set; }

		public SelectedServerDataExtendedMessage(ushort serverId, string address, IEnumerable<ushort> ports, bool canCreateNewCharacter, IEnumerable<sbyte> ticket, IEnumerable<GameServerInformations> servers)
		{
			this.serverId = serverId;
			this.address = address;
			this.ports = ports;
			this.canCreateNewCharacter = canCreateNewCharacter;
			this.ticket = ticket;
			this.servers = servers;
		}

		public SelectedServerDataExtendedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)servers.Count());
			foreach (var objectToSend in servers)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var serversCount = reader.ReadUShort();
			var servers_ = new GameServerInformations[serversCount];
			for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
			{
				var objectToAdd = new GameServerInformations();
				objectToAdd.Deserialize(reader);
				servers_[serversIndex] = objectToAdd;
			}
			servers = servers_;
		}

	}
}
