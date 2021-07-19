namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightReadyMessage : NetworkMessage
	{
		public const uint Id = 37;
		public override uint MessageId => Id;
		public bool isReady { get; set; }

		public GameFightReadyMessage(bool isReady)
		{
			this.isReady = isReady;
		}

		public GameFightReadyMessage() { }

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
