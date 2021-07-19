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
	public class StatedMapUpdateMessage : NetworkMessage
	{
		public const uint Id = 4814;
		public override uint MessageId => Id;
		public IEnumerable<StatedElement> statedElements { get; set; }

		public StatedMapUpdateMessage(IEnumerable<StatedElement> statedElements)
		{
			this.statedElements = statedElements;
		}

		public StatedMapUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)statedElements.Count());
			foreach (var objectToSend in statedElements)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var statedElementsCount = reader.ReadUShort();
			var statedElements_ = new StatedElement[statedElementsCount];
			for (var statedElementsIndex = 0; statedElementsIndex < statedElementsCount; statedElementsIndex++)
			{
				var objectToAdd = new StatedElement();
				objectToAdd.Deserialize(reader);
				statedElements_[statedElementsIndex] = objectToAdd;
			}
			statedElements = statedElements_;
		}

	}
}
