namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShowCellRequestMessage : NetworkMessage
	{
		public const uint Id = 5466;
		public override uint MessageId => Id;
		public ushort cellId { get; set; }

		public ShowCellRequestMessage(ushort cellId)
		{
			this.cellId = cellId;
		}

		public ShowCellRequestMessage() { }

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
