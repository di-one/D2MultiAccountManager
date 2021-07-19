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
	public class GameActionSpamMessage : NetworkMessage
	{
		public const uint Id = 8082;
		public override uint MessageId => Id;
		public IEnumerable<short> cells { get; set; }

		public GameActionSpamMessage(IEnumerable<short> cells)
		{
			this.cells = cells;
		}

		public GameActionSpamMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)cells.Count());
			foreach (var objectToSend in cells)
            {
				writer.WriteShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var cellsCount = reader.ReadUShort();
			var cells_ = new short[cellsCount];
			for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++)
			{
				cells_[cellsIndex] = reader.ReadShort();
			}
			cells = cells_;
		}

	}
}
