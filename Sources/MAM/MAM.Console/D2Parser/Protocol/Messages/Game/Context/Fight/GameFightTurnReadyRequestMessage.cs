namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightTurnReadyRequestMessage : NetworkMessage
	{
		public const uint Id = 5750;
		public override uint MessageId => Id;
		public double objectId { get; set; }

		public GameFightTurnReadyRequestMessage(double objectId)
		{
			this.objectId = objectId;
		}

		public GameFightTurnReadyRequestMessage() { }

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
