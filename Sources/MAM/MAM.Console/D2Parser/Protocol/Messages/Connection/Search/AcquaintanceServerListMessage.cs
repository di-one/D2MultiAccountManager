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
	public class AcquaintanceServerListMessage : NetworkMessage
	{
		public const uint Id = 6511;
		public override uint MessageId => Id;
		public IEnumerable<ushort> servers { get; set; }

		public AcquaintanceServerListMessage(IEnumerable<ushort> servers)
		{
			this.servers = servers;
		}

		public AcquaintanceServerListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)servers.Count());
			foreach (var objectToSend in servers)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var serversCount = reader.ReadUShort();
			var servers_ = new ushort[serversCount];
			for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
			{
				servers_[serversIndex] = reader.ReadVarUShort();
			}
			servers = servers_;
		}

	}
}
