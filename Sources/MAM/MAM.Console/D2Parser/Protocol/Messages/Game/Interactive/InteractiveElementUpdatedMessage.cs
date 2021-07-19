namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InteractiveElementUpdatedMessage : NetworkMessage
	{
		public const uint Id = 9844;
		public override uint MessageId => Id;
		public InteractiveElement interactiveElement { get; set; }

		public InteractiveElementUpdatedMessage(InteractiveElement interactiveElement)
		{
			this.interactiveElement = interactiveElement;
		}

		public InteractiveElementUpdatedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			interactiveElement.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			interactiveElement = new InteractiveElement();
			interactiveElement.Deserialize(reader);
		}

	}
}
