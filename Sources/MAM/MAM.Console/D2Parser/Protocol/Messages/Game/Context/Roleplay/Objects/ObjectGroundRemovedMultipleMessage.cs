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
	public class ObjectGroundRemovedMultipleMessage : NetworkMessage
	{
		public const uint Id = 5709;
		public override uint MessageId => Id;
		public IEnumerable<ushort> cells { get; set; }

		public ObjectGroundRemovedMultipleMessage(IEnumerable<ushort> cells)
		{
			this.cells = cells;
		}

		public ObjectGroundRemovedMultipleMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)cells.Count());
			foreach (var objectToSend in cells)
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
		}

	}
}
