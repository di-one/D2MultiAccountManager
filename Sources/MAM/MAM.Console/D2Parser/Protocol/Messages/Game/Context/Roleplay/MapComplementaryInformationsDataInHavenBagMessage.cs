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
	public class MapComplementaryInformationsDataInHavenBagMessage : MapComplementaryInformationsDataMessage
	{
		public new const uint Id = 8894;
		public override uint MessageId => Id;
		public CharacterMinimalInformations ownerInformations { get; set; }
		public sbyte theme { get; set; }
		public sbyte roomId { get; set; }
		public sbyte maxRoomId { get; set; }

		public MapComplementaryInformationsDataInHavenBagMessage(ushort subAreaId, double mapId, IEnumerable<HouseInformations> houses, IEnumerable<GameRolePlayActorInformations> actors, IEnumerable<InteractiveElement> interactiveElements, IEnumerable<StatedElement> statedElements, IEnumerable<MapObstacle> obstacles, IEnumerable<FightCommonInformations> fights, bool hasAggressiveMonsters, FightStartingPositions fightStartPositions, CharacterMinimalInformations ownerInformations, sbyte theme, sbyte roomId, sbyte maxRoomId)
		{
			this.subAreaId = subAreaId;
			this.mapId = mapId;
			this.houses = houses;
			this.actors = actors;
			this.interactiveElements = interactiveElements;
			this.statedElements = statedElements;
			this.obstacles = obstacles;
			this.fights = fights;
			this.hasAggressiveMonsters = hasAggressiveMonsters;
			this.fightStartPositions = fightStartPositions;
			this.ownerInformations = ownerInformations;
			this.theme = theme;
			this.roomId = roomId;
			this.maxRoomId = maxRoomId;
		}

		public MapComplementaryInformationsDataInHavenBagMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			ownerInformations.Serialize(writer);
			writer.WriteSByte(theme);
			writer.WriteSByte(roomId);
			writer.WriteSByte(maxRoomId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			ownerInformations = new CharacterMinimalInformations();
			ownerInformations.Deserialize(reader);
			theme = reader.ReadSByte();
			roomId = reader.ReadSByte();
			maxRoomId = reader.ReadSByte();
		}

	}
}
