namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionMark
	{
		public const short Id  = 8214;
		public virtual short TypeId => Id;
		public double markAuthorId { get; set; }
		public sbyte markTeamId { get; set; }
		public int markSpellId { get; set; }
		public short markSpellLevel { get; set; }
		public short markId { get; set; }
		public sbyte markType { get; set; }
		public short markimpactCell { get; set; }
		public IEnumerable<GameActionMarkedCell> cells { get; set; }
		public bool active { get; set; }

		public GameActionMark(double markAuthorId, sbyte markTeamId, int markSpellId, short markSpellLevel, short markId, sbyte markType, short markimpactCell, IEnumerable<GameActionMarkedCell> cells, bool active)
		{
			this.markAuthorId = markAuthorId;
			this.markTeamId = markTeamId;
			this.markSpellId = markSpellId;
			this.markSpellLevel = markSpellLevel;
			this.markId = markId;
			this.markType = markType;
			this.markimpactCell = markimpactCell;
			this.cells = cells;
			this.active = active;
		}

		public GameActionMark() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(markAuthorId);
			writer.WriteSByte(markTeamId);
			writer.WriteInt(markSpellId);
			writer.WriteShort(markSpellLevel);
			writer.WriteShort(markId);
			writer.WriteSByte(markType);
			writer.WriteShort(markimpactCell);
			writer.WriteShort((short)cells.Count());
			foreach (var objectToSend in cells)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteBoolean(active);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			markAuthorId = reader.ReadDouble();
			markTeamId = reader.ReadSByte();
			markSpellId = reader.ReadInt();
			markSpellLevel = reader.ReadShort();
			markId = reader.ReadShort();
			markType = reader.ReadSByte();
			markimpactCell = reader.ReadShort();
			var cellsCount = reader.ReadUShort();
			var cells_ = new GameActionMarkedCell[cellsCount];
			for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++)
			{
				var objectToAdd = new GameActionMarkedCell();
				objectToAdd.Deserialize(reader);
				cells_[cellsIndex] = objectToAdd;
			}
			cells = cells_;
			active = reader.ReadBoolean();
		}

	}
}
