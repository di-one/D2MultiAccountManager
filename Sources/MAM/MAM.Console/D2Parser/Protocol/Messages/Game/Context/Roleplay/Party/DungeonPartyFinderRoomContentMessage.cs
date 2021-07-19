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
	public class DungeonPartyFinderRoomContentMessage : NetworkMessage
	{
		public const uint Id = 7435;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }
		public IEnumerable<DungeonPartyFinderPlayer> players { get; set; }

		public DungeonPartyFinderRoomContentMessage(ushort dungeonId, IEnumerable<DungeonPartyFinderPlayer> players)
		{
			this.dungeonId = dungeonId;
			this.players = players;
		}

		public DungeonPartyFinderRoomContentMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(dungeonId);
			writer.WriteShort((short)players.Count());
			foreach (var objectToSend in players)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			dungeonId = reader.ReadVarUShort();
			var playersCount = reader.ReadUShort();
			var players_ = new DungeonPartyFinderPlayer[playersCount];
			for (var playersIndex = 0; playersIndex < playersCount; playersIndex++)
			{
				var objectToAdd = new DungeonPartyFinderPlayer();
				objectToAdd.Deserialize(reader);
				players_[playersIndex] = objectToAdd;
			}
			players = players_;
		}

	}
}
