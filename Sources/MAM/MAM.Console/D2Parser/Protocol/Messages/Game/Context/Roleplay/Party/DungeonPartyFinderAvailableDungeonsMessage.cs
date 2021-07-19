﻿namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class DungeonPartyFinderAvailableDungeonsMessage : NetworkMessage
	{
		public const uint Id = 9154;
		public override uint MessageId => Id;
		public IEnumerable<ushort> dungeonIds { get; set; }

		public DungeonPartyFinderAvailableDungeonsMessage(IEnumerable<ushort> dungeonIds)
		{
			this.dungeonIds = dungeonIds;
		}

		public DungeonPartyFinderAvailableDungeonsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)dungeonIds.Count());
			foreach (var objectToSend in dungeonIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var dungeonIdsCount = reader.ReadUShort();
			var dungeonIds_ = new ushort[dungeonIdsCount];
			for (var dungeonIdsIndex = 0; dungeonIdsIndex < dungeonIdsCount; dungeonIdsIndex++)
			{
				dungeonIds_[dungeonIdsIndex] = reader.ReadVarUShort();
			}
			dungeonIds = dungeonIds_;
		}

	}
}
