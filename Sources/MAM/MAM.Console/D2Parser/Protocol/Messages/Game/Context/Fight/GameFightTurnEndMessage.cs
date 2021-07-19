namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightTurnEndMessage : NetworkMessage
	{
		public const uint Id = 6535;
		public override uint MessageId => Id;
		public double objectId { get; set; }

		public GameFightTurnEndMessage(double objectId)
		{
			this.objectId = objectId;
		}

		public GameFightTurnEndMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(objectId);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadDouble();
		}

	}
}
