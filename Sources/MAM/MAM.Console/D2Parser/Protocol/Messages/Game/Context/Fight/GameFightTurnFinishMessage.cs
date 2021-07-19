namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightTurnFinishMessage : NetworkMessage
	{
		public const uint Id = 8033;
		public override uint MessageId => Id;
		public bool isAfk { get; set; }

		public GameFightTurnFinishMessage(bool isAfk)
		{
			this.isAfk = isAfk;
		}

		public GameFightTurnFinishMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(isAfk);
		}

		public override void Deserialize(IDataReader reader)
		{
			isAfk = reader.ReadBoolean();
		}

	}
}
