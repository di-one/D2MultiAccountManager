namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightPlacementSwapPositionsCancelMessage : NetworkMessage
	{
		public const uint Id = 7979;
		public override uint MessageId => Id;
		public int requestId { get; set; }

		public GameFightPlacementSwapPositionsCancelMessage(int requestId)
		{
			this.requestId = requestId;
		}

		public GameFightPlacementSwapPositionsCancelMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(requestId);
		}

		public override void Deserialize(IDataReader reader)
		{
			requestId = reader.ReadInt();
		}

	}
}
