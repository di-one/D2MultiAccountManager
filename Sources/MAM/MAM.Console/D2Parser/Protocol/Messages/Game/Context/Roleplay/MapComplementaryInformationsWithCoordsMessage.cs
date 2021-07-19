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
	public class MapComplementaryInformationsWithCoordsMessage : MapComplementaryInformationsDataMessage
	{
		public new const uint Id = 6445;
		public override uint MessageId => Id;
		public short worldX { get; set; }
		public short worldY { get; set; }

		public MapComplementaryInformationsWithCoordsMessage(ushort subAreaId, double mapId, IEnumerable<HouseInformations> houses, IEnumerable<GameRolePlayActorInformations> actors, IEnumerable<InteractiveElement> interactiveElements, IEnumerable<StatedElement> statedElements, IEnumerable<MapObstacle> obstacles, IEnumerable<FightCommonInformations> fights, bool hasAggressiveMonsters, FightStartingPositions fightStartPositions, short worldX, short worldY)
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
			this.worldX = worldX;
			this.worldY = worldY;
		}

		public MapComplementaryInformationsWithCoordsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
		}

	}
}
