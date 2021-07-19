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
	public class GameContextRemoveMultipleElementsMessage : NetworkMessage
	{
		public const uint Id = 9535;
		public override uint MessageId => Id;
		public IEnumerable<double> elementsIds { get; set; }

		public GameContextRemoveMultipleElementsMessage(IEnumerable<double> elementsIds)
		{
			this.elementsIds = elementsIds;
		}

		public GameContextRemoveMultipleElementsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)elementsIds.Count());
			foreach (var objectToSend in elementsIds)
            {
				writer.WriteDouble(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var elementsIdsCount = reader.ReadUShort();
			var elementsIds_ = new double[elementsIdsCount];
			for (var elementsIdsIndex = 0; elementsIdsIndex < elementsIdsCount; elementsIdsIndex++)
			{
				elementsIds_[elementsIdsIndex] = reader.ReadDouble();
			}
			elementsIds = elementsIds_;
		}

	}
}
