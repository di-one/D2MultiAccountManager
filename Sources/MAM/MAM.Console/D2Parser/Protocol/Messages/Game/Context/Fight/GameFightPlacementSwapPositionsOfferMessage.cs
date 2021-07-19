namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightPlacementSwapPositionsOfferMessage : NetworkMessage
	{
		public const uint Id = 2478;
		public override uint MessageId => Id;
		public int requestId { get; set; }
		public double requesterId { get; set; }
		public ushort requesterCellId { get; set; }
		public double requestedId { get; set; }
		public ushort requestedCellId { get; set; }

		public GameFightPlacementSwapPositionsOfferMessage(int requestId, double requesterId, ushort requesterCellId, double requestedId, ushort requestedCellId)
		{
			this.requestId = requestId;
			this.requesterId = requesterId;
			this.requesterCellId = requesterCellId;
			this.requestedId = requestedId;
			this.requestedCellId = requestedCellId;
		}

		public GameFightPlacementSwapPositionsOfferMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(requestId);
			writer.WriteDouble(requesterId);
			writer.WriteVarUShort(requesterCellId);
			writer.WriteDouble(requestedId);
			writer.WriteVarUShort(requestedCellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			requestId = reader.ReadInt();
			requesterId = reader.ReadDouble();
			requesterCellId = reader.ReadVarUShort();
			requestedId = reader.ReadDouble();
			requestedCellId = reader.ReadVarUShort();
		}

	}
}
