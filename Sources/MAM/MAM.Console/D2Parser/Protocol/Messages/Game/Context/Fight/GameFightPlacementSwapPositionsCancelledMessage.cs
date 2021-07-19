namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightPlacementSwapPositionsCancelledMessage : NetworkMessage
	{
		public const uint Id = 4242;
		public override uint MessageId => Id;
		public int requestId { get; set; }
		public double cancellerId { get; set; }

		public GameFightPlacementSwapPositionsCancelledMessage(int requestId, double cancellerId)
		{
			this.requestId = requestId;
			this.cancellerId = cancellerId;
		}

		public GameFightPlacementSwapPositionsCancelledMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(requestId);
			writer.WriteDouble(cancellerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			requestId = reader.ReadInt();
			cancellerId = reader.ReadDouble();
		}

	}
}
