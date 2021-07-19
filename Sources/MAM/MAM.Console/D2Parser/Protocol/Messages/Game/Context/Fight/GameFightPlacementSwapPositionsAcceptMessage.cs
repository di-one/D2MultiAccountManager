namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightPlacementSwapPositionsAcceptMessage : NetworkMessage
	{
		public const uint Id = 2673;
		public override uint MessageId => Id;
		public int requestId { get; set; }

		public GameFightPlacementSwapPositionsAcceptMessage(int requestId)
		{
			this.requestId = requestId;
		}

		public GameFightPlacementSwapPositionsAcceptMessage() { }

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
