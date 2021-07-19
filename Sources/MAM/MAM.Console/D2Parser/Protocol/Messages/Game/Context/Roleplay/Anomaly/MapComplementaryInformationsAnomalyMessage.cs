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
	public class MapComplementaryInformationsAnomalyMessage : MapComplementaryInformationsDataMessage
	{
		public new const uint Id = 5651;
		public override uint MessageId => Id;
		public ushort level { get; set; }
		public ulong closingTime { get; set; }

		public MapComplementaryInformationsAnomalyMessage(ushort subAreaId, double mapId, IEnumerable<HouseInformations> houses, IEnumerable<GameRolePlayActorInformations> actors, IEnumerable<InteractiveElement> interactiveElements, IEnumerable<StatedElement> statedElements, IEnumerable<MapObstacle> obstacles, IEnumerable<FightCommonInformations> fights, bool hasAggressiveMonsters, FightStartingPositions fightStartPositions, ushort level, ulong closingTime)
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
			this.level = level;
			this.closingTime = closingTime;
		}

		public MapComplementaryInformationsAnomalyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(level);
			writer.WriteVarULong(closingTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			level = reader.ReadVarUShort();
			closingTime = reader.ReadVarULong();
		}

	}
}
