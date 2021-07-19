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
	public class MapObstacleUpdateMessage : NetworkMessage
	{
		public const uint Id = 3135;
		public override uint MessageId => Id;
		public IEnumerable<MapObstacle> obstacles { get; set; }

		public MapObstacleUpdateMessage(IEnumerable<MapObstacle> obstacles)
		{
			this.obstacles = obstacles;
		}

		public MapObstacleUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)obstacles.Count());
			foreach (var objectToSend in obstacles)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var obstaclesCount = reader.ReadUShort();
			var obstacles_ = new MapObstacle[obstaclesCount];
			for (var obstaclesIndex = 0; obstaclesIndex < obstaclesCount; obstaclesIndex++)
			{
				var objectToAdd = new MapObstacle();
				objectToAdd.Deserialize(reader);
				obstacles_[obstaclesIndex] = objectToAdd;
			}
			obstacles = obstacles_;
		}

	}
}
