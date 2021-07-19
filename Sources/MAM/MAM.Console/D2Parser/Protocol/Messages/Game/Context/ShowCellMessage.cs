namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShowCellMessage : NetworkMessage
	{
		public const uint Id = 7307;
		public override uint MessageId => Id;
		public double sourceId { get; set; }
		public ushort cellId { get; set; }

		public ShowCellMessage(double sourceId, ushort cellId)
		{
			this.sourceId = sourceId;
			this.cellId = cellId;
		}

		public ShowCellMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(sourceId);
			writer.WriteVarUShort(cellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			sourceId = reader.ReadDouble();
			cellId = reader.ReadVarUShort();
		}

	}
}
