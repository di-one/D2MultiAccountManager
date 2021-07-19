namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StatedElementUpdatedMessage : NetworkMessage
	{
		public const uint Id = 4006;
		public override uint MessageId => Id;
		public StatedElement statedElement { get; set; }

		public StatedElementUpdatedMessage(StatedElement statedElement)
		{
			this.statedElement = statedElement;
		}

		public StatedElementUpdatedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			statedElement.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			statedElement = new StatedElement();
			statedElement.Deserialize(reader);
		}

	}
}
