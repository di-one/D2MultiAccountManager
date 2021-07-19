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
	public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
	{
		public new const uint Id = 3195;
		public override uint MessageId => Id;
		public HouseInformationsInside currentHouse { get; set; }

		public MapComplementaryInformationsDataInHouseMessage(ushort subAreaId, double mapId, IEnumerable<HouseInformations> houses, IEnumerable<GameRolePlayActorInformations> actors, IEnumerable<InteractiveElement> interactiveElements, IEnumerable<StatedElement> statedElements, IEnumerable<MapObstacle> obstacles, IEnumerable<FightCommonInformations> fights, bool hasAggressiveMonsters, FightStartingPositions fightStartPositions, HouseInformationsInside currentHouse)
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
			this.currentHouse = currentHouse;
		}

		public MapComplementaryInformationsDataInHouseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			currentHouse.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			currentHouse = new HouseInformationsInside();
			currentHouse.Deserialize(reader);
		}

	}
}
