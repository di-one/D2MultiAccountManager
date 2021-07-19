namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MimicryObjectPreviewMessage : NetworkMessage
	{
		public const uint Id = 7339;
		public override uint MessageId => Id;
		public ObjectItem result { get; set; }

		public MimicryObjectPreviewMessage(ObjectItem result)
		{
			this.result = result;
		}

		public MimicryObjectPreviewMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			result.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			result = new ObjectItem();
			result.Deserialize(reader);
		}

	}
}
