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
	public class GameContextRemoveMultipleElementsWithEventsMessage : GameContextRemoveMultipleElementsMessage
	{
		public new const uint Id = 3428;
		public override uint MessageId => Id;
		public IEnumerable<byte> elementEventIds { get; set; }

		public GameContextRemoveMultipleElementsWithEventsMessage(IEnumerable<double> elementsIds, IEnumerable<byte> elementEventIds)
		{
			this.elementsIds = elementsIds;
			this.elementEventIds = elementEventIds;
		}

		public GameContextRemoveMultipleElementsWithEventsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)elementEventIds.Count());
			foreach (var objectToSend in elementEventIds)
            {
				writer.WriteByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var elementEventIdsCount = reader.ReadUShort();
			var elementEventIds_ = new byte[elementEventIdsCount];
			for (var elementEventIdsIndex = 0; elementEventIdsIndex < elementEventIdsCount; elementEventIdsIndex++)
			{
				elementEventIds_[elementEventIdsIndex] = reader.ReadByte();
			}
			elementEventIds = elementEventIds_;
		}

	}
}
