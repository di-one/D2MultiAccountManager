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
	public class DungeonPartyFinderRoomContentUpdateMessage : NetworkMessage
	{
		public const uint Id = 2889;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }
		public IEnumerable<DungeonPartyFinderPlayer> addedPlayers { get; set; }
		public IEnumerable<ulong> removedPlayersIds { get; set; }

		public DungeonPartyFinderRoomContentUpdateMessage(ushort dungeonId, IEnumerable<DungeonPartyFinderPlayer> addedPlayers, IEnumerable<ulong> removedPlayersIds)
		{
			this.dungeonId = dungeonId;
			this.addedPlayers = addedPlayers;
			this.removedPlayersIds = removedPlayersIds;
		}

		public DungeonPartyFinderRoomContentUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(dungeonId);
			writer.WriteShort((short)addedPlayers.Count());
			foreach (var objectToSend in addedPlayers)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)removedPlayersIds.Count());
			foreach (var objectToSend in removedPlayersIds)
            {
				writer.WriteVarULong(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			dungeonId = reader.ReadVarUShort();
			var addedPlayersCount = reader.ReadUShort();
			var addedPlayers_ = new DungeonPartyFinderPlayer[addedPlayersCount];
			for (var addedPlayersIndex = 0; addedPlayersIndex < addedPlayersCount; addedPlayersIndex++)
			{
				var objectToAdd = new DungeonPartyFinderPlayer();
				objectToAdd.Deserialize(reader);
				addedPlayers_[addedPlayersIndex] = objectToAdd;
			}
			addedPlayers = addedPlayers_;
			var removedPlayersIdsCount = reader.ReadUShort();
			var removedPlayersIds_ = new ulong[removedPlayersIdsCount];
			for (var removedPlayersIdsIndex = 0; removedPlayersIdsIndex < removedPlayersIdsCount; removedPlayersIdsIndex++)
			{
				removedPlayersIds_[removedPlayersIdsIndex] = reader.ReadVarULong();
			}
			removedPlayersIds = removedPlayersIds_;
		}

	}
}
