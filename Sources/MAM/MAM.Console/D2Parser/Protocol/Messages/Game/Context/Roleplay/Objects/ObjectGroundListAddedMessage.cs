namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectGroundListAddedMessage : NetworkMessage
	{
		public const uint Id = 7865;
		public override uint MessageId => Id;
		public IEnumerable<ushort> cells { get; set; }
		public IEnumerable<ushort> referenceIds { get; set; }

		public ObjectGroundListAddedMessage(IEnumerable<ushort> cells, IEnumerable<ushort> referenceIds)
		{
			this.cells = cells;
			this.referenceIds = referenceIds;
		}

		public ObjectGroundListAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)cells.Count());
			foreach (var objectToSend in cells)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)referenceIds.Count());
			foreach (var objectToSend in referenceIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var cellsCount = reader.ReadUShort();
			var cells_ = new ushort[cellsCount];
			for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++)
			{
				cells_[cellsIndex] = reader.ReadVarUShort();
			}
			cells = cells_;
			var referenceIdsCount = reader.ReadUShort();
			var referenceIds_ = new ushort[referenceIdsCount];
			for (var referenceIdsIndex = 0; referenceIdsIndex < referenceIdsCount; referenceIdsIndex++)
			{
				referenceIds_[referenceIdsIndex] = reader.ReadVarUShort();
			}
			referenceIds = referenceIds_;
		}

	}
}
