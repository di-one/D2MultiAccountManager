namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightTurnReadyMessage : NetworkMessage
	{
		public const uint Id = 1827;
		public override uint MessageId => Id;
		public bool isReady { get; set; }

		public GameFightTurnReadyMessage(bool isReady)
		{
			this.isReady = isReady;
		}

		public GameFightTurnReadyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(isReady);
		}

		public override void Deserialize(IDataReader reader)
		{
			isReady = reader.ReadBoolean();
		}

	}
}
