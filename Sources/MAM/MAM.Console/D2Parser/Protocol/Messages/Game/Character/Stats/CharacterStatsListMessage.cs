namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterStatsListMessage : NetworkMessage
	{
		public const uint Id = 8054;
		public override uint MessageId => Id;
		public CharacterCharacteristicsInformations stats { get; set; }

		public CharacterStatsListMessage(CharacterCharacteristicsInformations stats)
		{
			this.stats = stats;
		}

		public CharacterStatsListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			stats.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			stats = new CharacterCharacteristicsInformations();
			stats.Deserialize(reader);
		}

	}
}
