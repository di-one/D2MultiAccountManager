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
	public class MigratedServerListMessage : NetworkMessage
	{
		public const uint Id = 1829;
		public override uint MessageId => Id;
		public IEnumerable<ushort> migratedServerIds { get; set; }

		public MigratedServerListMessage(IEnumerable<ushort> migratedServerIds)
		{
			this.migratedServerIds = migratedServerIds;
		}

		public MigratedServerListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)migratedServerIds.Count());
			foreach (var objectToSend in migratedServerIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var migratedServerIdsCount = reader.ReadUShort();
			var migratedServerIds_ = new ushort[migratedServerIdsCount];
			for (var migratedServerIdsIndex = 0; migratedServerIdsIndex < migratedServerIdsCount; migratedServerIdsIndex++)
			{
				migratedServerIds_[migratedServerIdsIndex] = reader.ReadVarUShort();
			}
			migratedServerIds = migratedServerIds_;
		}

	}
}
