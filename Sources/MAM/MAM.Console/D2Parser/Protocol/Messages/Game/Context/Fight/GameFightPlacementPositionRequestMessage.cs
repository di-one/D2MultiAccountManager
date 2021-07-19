namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightPlacementPositionRequestMessage : NetworkMessage
	{
		public const uint Id = 5598;
		public override uint MessageId => Id;
		public ushort cellId { get; set; }

		public GameFightPlacementPositionRequestMessage(ushort cellId)
		{
			this.cellId = cellId;
		}

		public GameFightPlacementPositionRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(cellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			cellId = reader.ReadVarUShort();
		}

	}
}
