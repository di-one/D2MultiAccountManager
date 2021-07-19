namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterSelectedSuccessMessage : NetworkMessage
	{
		public const uint Id = 7662;
		public override uint MessageId => Id;
		public CharacterBaseInformations infos { get; set; }
		public bool isCollectingStats { get; set; }

		public CharacterSelectedSuccessMessage(CharacterBaseInformations infos, bool isCollectingStats)
		{
			this.infos = infos;
			this.isCollectingStats = isCollectingStats;
		}

		public CharacterSelectedSuccessMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			infos.Serialize(writer);
			writer.WriteBoolean(isCollectingStats);
		}

		public override void Deserialize(IDataReader reader)
		{
			infos = new CharacterBaseInformations();
			infos.Deserialize(reader);
			isCollectingStats = reader.ReadBoolean();
		}

	}
}
