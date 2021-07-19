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
	public class MapComplementaryInformationsBreachMessage : MapComplementaryInformationsDataMessage
	{
		public new const uint Id = 125;
		public override uint MessageId => Id;
		public uint floor { get; set; }
		public sbyte room { get; set; }
		public short infinityMode { get; set; }
		public IEnumerable<BreachBranch> branches { get; set; }

		public MapComplementaryInformationsBreachMessage(ushort subAreaId, double mapId, IEnumerable<HouseInformations> houses, IEnumerable<GameRolePlayActorInformations> actors, IEnumerable<InteractiveElement> interactiveElements, IEnumerable<StatedElement> statedElements, IEnumerable<MapObstacle> obstacles, IEnumerable<FightCommonInformations> fights, bool hasAggressiveMonsters, FightStartingPositions fightStartPositions, uint floor, sbyte room, short infinityMode, IEnumerable<BreachBranch> branches)
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
			this.floor = floor;
			this.room = room;
			this.infinityMode = infinityMode;
			this.branches = branches;
		}

		public MapComplementaryInformationsBreachMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(floor);
			writer.WriteSByte(room);
			writer.WriteShort(infinityMode);
			writer.WriteShort((short)branches.Count());
			foreach (var objectToSend in branches)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			floor = reader.ReadVarUInt();
			room = reader.ReadSByte();
			infinityMode = reader.ReadShort();
			var branchesCount = reader.ReadUShort();
			var branches_ = new BreachBranch[branchesCount];
			for (var branchesIndex = 0; branchesIndex < branchesCount; branchesIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<BreachBranch>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				branches_[branchesIndex] = objectToAdd;
			}
			branches = branches_;
		}

	}
}
