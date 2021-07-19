namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightPlacementSwapPositionsRequestMessage : GameFightPlacementPositionRequestMessage
	{
		public new const uint Id = 9716;
		public override uint MessageId => Id;
		public double requestedId { get; set; }

		public GameFightPlacementSwapPositionsRequestMessage(ushort cellId, double requestedId)
		{
			this.cellId = cellId;
			this.requestedId = requestedId;
		}

		public GameFightPlacementSwapPositionsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(requestedId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			requestedId = reader.ReadDouble();
		}

	}
}
