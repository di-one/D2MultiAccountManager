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
	public class InteractiveMapUpdateMessage : NetworkMessage
	{
		public const uint Id = 6385;
		public override uint MessageId => Id;
		public IEnumerable<InteractiveElement> interactiveElements { get; set; }

		public InteractiveMapUpdateMessage(IEnumerable<InteractiveElement> interactiveElements)
		{
			this.interactiveElements = interactiveElements;
		}

		public InteractiveMapUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)interactiveElements.Count());
			foreach (var objectToSend in interactiveElements)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var interactiveElementsCount = reader.ReadUShort();
			var interactiveElements_ = new InteractiveElement[interactiveElementsCount];
			for (var interactiveElementsIndex = 0; interactiveElementsIndex < interactiveElementsCount; interactiveElementsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				interactiveElements_[interactiveElementsIndex] = objectToAdd;
			}
			interactiveElements = interactiveElements_;
		}

	}
}
