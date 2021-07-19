namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MapFightStartPositionsUpdateMessage : NetworkMessage
	{
		public const uint Id = 7470;
		public override uint MessageId => Id;
		public double mapId { get; set; }
		public FightStartingPositions fightStartPositions { get; set; }

		public MapFightStartPositionsUpdateMessage(double mapId, FightStartingPositions fightStartPositions)
		{
			this.mapId = mapId;
			this.fightStartPositions = fightStartPositions;
		}

		public MapFightStartPositionsUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(mapId);
			fightStartPositions.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			mapId = reader.ReadDouble();
			fightStartPositions = new FightStartingPositions();
			fightStartPositions.Deserialize(reader);
		}

	}
}
