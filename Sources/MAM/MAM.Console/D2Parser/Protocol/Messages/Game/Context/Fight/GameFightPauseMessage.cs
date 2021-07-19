namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightPauseMessage : NetworkMessage
	{
		public const uint Id = 6391;
		public override uint MessageId => Id;
		public bool isPaused { get; set; }

		public GameFightPauseMessage(bool isPaused)
		{
			this.isPaused = isPaused;
		}

		public GameFightPauseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(isPaused);
		}

		public override void Deserialize(IDataReader reader)
		{
			isPaused = reader.ReadBoolean();
		}

	}
}
