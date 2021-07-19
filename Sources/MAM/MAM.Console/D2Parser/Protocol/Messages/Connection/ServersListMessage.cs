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
	public class ServersListMessage : NetworkMessage
	{
		public const uint Id = 4096;
		public override uint MessageId => Id;
		public IEnumerable<GameServerInformations> servers { get; set; }
		public ushort alreadyConnectedToServerId { get; set; }
		public bool canCreateNewCharacter { get; set; }

		public ServersListMessage(IEnumerable<GameServerInformations> servers, ushort alreadyConnectedToServerId, bool canCreateNewCharacter)
		{
			this.servers = servers;
			this.alreadyConnectedToServerId = alreadyConnectedToServerId;
			this.canCreateNewCharacter = canCreateNewCharacter;
		}

		public ServersListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)servers.Count());
			foreach (var objectToSend in servers)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteVarUShort(alreadyConnectedToServerId);
			writer.WriteBoolean(canCreateNewCharacter);
		}

		public override void Deserialize(IDataReader reader)
		{
			var serversCount = reader.ReadUShort();
			var servers_ = new GameServerInformations[serversCount];
			for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
			{
				var objectToAdd = new GameServerInformations();
				objectToAdd.Deserialize(reader);
				servers_[serversIndex] = objectToAdd;
			}
			servers = servers_;
			alreadyConnectedToServerId = reader.ReadVarUShort();
			canCreateNewCharacter = reader.ReadBoolean();
		}

	}
}
