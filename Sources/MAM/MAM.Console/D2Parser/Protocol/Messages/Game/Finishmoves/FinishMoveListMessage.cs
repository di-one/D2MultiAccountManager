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
	public class FinishMoveListMessage : NetworkMessage
	{
		public const uint Id = 5286;
		public override uint MessageId => Id;
		public IEnumerable<FinishMoveInformations> finishMoves { get; set; }

		public FinishMoveListMessage(IEnumerable<FinishMoveInformations> finishMoves)
		{
			this.finishMoves = finishMoves;
		}

		public FinishMoveListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)finishMoves.Count());
			foreach (var objectToSend in finishMoves)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var finishMovesCount = reader.ReadUShort();
			var finishMoves_ = new FinishMoveInformations[finishMovesCount];
			for (var finishMovesIndex = 0; finishMovesIndex < finishMovesCount; finishMovesIndex++)
			{
				var objectToAdd = new FinishMoveInformations();
				objectToAdd.Deserialize(reader);
				finishMoves_[finishMovesIndex] = objectToAdd;
			}
			finishMoves = finishMoves_;
		}

	}
}
