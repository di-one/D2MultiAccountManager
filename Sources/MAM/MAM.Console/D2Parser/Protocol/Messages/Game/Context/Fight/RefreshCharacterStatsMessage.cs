namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class RefreshCharacterStatsMessage : NetworkMessage
	{
		public const uint Id = 6509;
		public override uint MessageId => Id;
		public double fighterId { get; set; }
		public GameFightCharacteristics stats { get; set; }

		public RefreshCharacterStatsMessage(double fighterId, GameFightCharacteristics stats)
		{
			this.fighterId = fighterId;
			this.stats = stats;
		}

		public RefreshCharacterStatsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(fighterId);
			stats.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			fighterId = reader.ReadDouble();
			stats = new GameFightCharacteristics();
			stats.Deserialize(reader);
		}

	}
}
