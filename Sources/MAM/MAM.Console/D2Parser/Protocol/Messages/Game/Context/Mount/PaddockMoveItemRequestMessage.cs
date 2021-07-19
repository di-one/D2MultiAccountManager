namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockMoveItemRequestMessage : NetworkMessage
	{
		public const uint Id = 630;
		public override uint MessageId => Id;
		public ushort oldCellId { get; set; }
		public ushort newCellId { get; set; }

		public PaddockMoveItemRequestMessage(ushort oldCellId, ushort newCellId)
		{
			this.oldCellId = oldCellId;
			this.newCellId = newCellId;
		}

		public PaddockMoveItemRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(oldCellId);
			writer.WriteVarUShort(newCellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			oldCellId = reader.ReadVarUShort();
			newCellId = reader.ReadVarUShort();
		}

	}
}
