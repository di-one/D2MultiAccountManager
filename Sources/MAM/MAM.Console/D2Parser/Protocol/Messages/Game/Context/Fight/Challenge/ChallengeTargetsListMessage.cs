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
	public class ChallengeTargetsListMessage : NetworkMessage
	{
		public const uint Id = 1509;
		public override uint MessageId => Id;
		public IEnumerable<double> targetIds { get; set; }
		public IEnumerable<short> targetCells { get; set; }

		public ChallengeTargetsListMessage(IEnumerable<double> targetIds, IEnumerable<short> targetCells)
		{
			this.targetIds = targetIds;
			this.targetCells = targetCells;
		}

		public ChallengeTargetsListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)targetIds.Count());
			foreach (var objectToSend in targetIds)
            {
				writer.WriteDouble(objectToSend);
			}
			writer.WriteShort((short)targetCells.Count());
			foreach (var objectToSend in targetCells)
            {
				writer.WriteShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var targetIdsCount = reader.ReadUShort();
			var targetIds_ = new double[targetIdsCount];
			for (var targetIdsIndex = 0; targetIdsIndex < targetIdsCount; targetIdsIndex++)
			{
				targetIds_[targetIdsIndex] = reader.ReadDouble();
			}
			targetIds = targetIds_;
			var targetCellsCount = reader.ReadUShort();
			var targetCells_ = new short[targetCellsCount];
			for (var targetCellsIndex = 0; targetCellsIndex < targetCellsCount; targetCellsIndex++)
			{
				targetCells_[targetCellsIndex] = reader.ReadShort();
			}
			targetCells = targetCells_;
		}

	}
}
