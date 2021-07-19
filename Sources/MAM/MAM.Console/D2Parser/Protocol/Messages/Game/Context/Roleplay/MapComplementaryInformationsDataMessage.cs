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
	public class MapComplementaryInformationsDataMessage : NetworkMessage
	{
		public const uint Id = 7028;
		public override uint MessageId => Id;
		public ushort subAreaId { get; set; }
		public double mapId { get; set; }
		public IEnumerable<HouseInformations> houses { get; set; }
		public IEnumerable<GameRolePlayActorInformations> actors { get; set; }
		public IEnumerable<InteractiveElement> interactiveElements { get; set; }
		public IEnumerable<StatedElement> statedElements { get; set; }
		public IEnumerable<MapObstacle> obstacles { get; set; }
		public IEnumerable<FightCommonInformations> fights { get; set; }
		public bool hasAggressiveMonsters { get; set; }
		public FightStartingPositions fightStartPositions { get; set; }

		public MapComplementaryInformationsDataMessage(ushort subAreaId, double mapId, IEnumerable<HouseInformations> houses, IEnumerable<GameRolePlayActorInformations> actors, IEnumerable<InteractiveElement> interactiveElements, IEnumerable<StatedElement> statedElements, IEnumerable<MapObstacle> obstacles, IEnumerable<FightCommonInformations> fights, bool hasAggressiveMonsters, FightStartingPositions fightStartPositions)
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
		}

		public MapComplementaryInformationsDataMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteDouble(mapId);
			writer.WriteShort((short)houses.Count());
			foreach (var objectToSend in houses)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)actors.Count());
			foreach (var objectToSend in actors)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)interactiveElements.Count());
			foreach (var objectToSend in interactiveElements)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)statedElements.Count());
			foreach (var objectToSend in statedElements)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)obstacles.Count());
			foreach (var objectToSend in obstacles)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)fights.Count());
			foreach (var objectToSend in fights)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteBoolean(hasAggressiveMonsters);
			fightStartPositions.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			mapId = reader.ReadDouble();
			var housesCount = reader.ReadUShort();
			var houses_ = new HouseInformations[housesCount];
			for (var housesIndex = 0; housesIndex < housesCount; housesIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<HouseInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				houses_[housesIndex] = objectToAdd;
			}
			houses = houses_;
			var actorsCount = reader.ReadUShort();
			var actors_ = new GameRolePlayActorInformations[actorsCount];
			for (var actorsIndex = 0; actorsIndex < actorsCount; actorsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				actors_[actorsIndex] = objectToAdd;
			}
			actors = actors_;
			var interactiveElementsCount = reader.ReadUShort();
			var interactiveElements_ = new InteractiveElement[interactiveElementsCount];
			for (var interactiveElementsIndex = 0; interactiveElementsIndex < interactiveElementsCount; interactiveElementsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				interactiveElements_[interactiveElementsIndex] = objectToAdd;
			}
			interactiveElements = interactiveElements_;
			var statedElementsCount = reader.ReadUShort();
			var statedElements_ = new StatedElement[statedElementsCount];
			for (var statedElementsIndex = 0; statedElementsIndex < statedElementsCount; statedElementsIndex++)
			{
				var objectToAdd = new StatedElement();
				objectToAdd.Deserialize(reader);
				statedElements_[statedElementsIndex] = objectToAdd;
			}
			statedElements = statedElements_;
			var obstaclesCount = reader.ReadUShort();
			var obstacles_ = new MapObstacle[obstaclesCount];
			for (var obstaclesIndex = 0; obstaclesIndex < obstaclesCount; obstaclesIndex++)
			{
				var objectToAdd = new MapObstacle();
				objectToAdd.Deserialize(reader);
				obstacles_[obstaclesIndex] = objectToAdd;
			}
			obstacles = obstacles_;
			var fightsCount = reader.ReadUShort();
			var fights_ = new FightCommonInformations[fightsCount];
			for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
			{
				var objectToAdd = new FightCommonInformations();
				objectToAdd.Deserialize(reader);
				fights_[fightsIndex] = objectToAdd;
			}
			fights = fights_;
			hasAggressiveMonsters = reader.ReadBoolean();
			fightStartPositions = new FightStartingPositions();
			fightStartPositions.Deserialize(reader);
		}

	}
}
