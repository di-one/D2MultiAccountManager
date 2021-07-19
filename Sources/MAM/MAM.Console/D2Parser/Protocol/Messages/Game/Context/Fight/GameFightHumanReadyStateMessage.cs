namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightHumanReadyStateMessage : NetworkMessage
	{
		public const uint Id = 2996;
		public override uint MessageId => Id;
		public ulong characterId { get; set; }
		public bool isReady { get; set; }

		public GameFightHumanReadyStateMessage(ulong characterId, bool isReady)
		{
			this.characterId = characterId;
			this.isReady = isReady;
		}

		public GameFightHumanReadyStateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(characterId);
			writer.WriteBoolean(isReady);
		}

		public override void Deserialize(IDataReader reader)
		{
			characterId = reader.ReadVarULong();
			isReady = reader.ReadBoolean();
		}

	}
}
