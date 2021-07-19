namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ServerStatusUpdateMessage : NetworkMessage
	{
		public const uint Id = 6615;
		public override uint MessageId => Id;
		public GameServerInformations server { get; set; }

		public ServerStatusUpdateMessage(GameServerInformations server)
		{
			this.server = server;
		}

		public ServerStatusUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			server.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			server = new GameServerInformations();
			server.Deserialize(reader);
		}

	}
}
