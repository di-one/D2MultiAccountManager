namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameMapMovementCancelMessage : NetworkMessage
	{
		public const uint Id = 2307;
		public override uint MessageId => Id;
		public ushort cellId { get; set; }

		public GameMapMovementCancelMessage(ushort cellId)
		{
			this.cellId = cellId;
		}

		public GameMapMovementCancelMessage() { }

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
