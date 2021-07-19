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
	public class GameDataPlayFarmObjectAnimationMessage : NetworkMessage
	{
		public const uint Id = 7144;
		public override uint MessageId => Id;
		public IEnumerable<ushort> cellId { get; set; }

		public GameDataPlayFarmObjectAnimationMessage(IEnumerable<ushort> cellId)
		{
			this.cellId = cellId;
		}

		public GameDataPlayFarmObjectAnimationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)cellId.Count());
			foreach (var objectToSend in cellId)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var cellIdCount = reader.ReadUShort();
			var cellId_ = new ushort[cellIdCount];
			for (var cellIdIndex = 0; cellIdIndex < cellIdCount; cellIdIndex++)
			{
				cellId_[cellIdIndex] = reader.ReadVarUShort();
			}
			cellId = cellId_;
		}

	}
}
