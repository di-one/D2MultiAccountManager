namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StorageObjectUpdateMessage : NetworkMessage
	{
		public const uint Id = 3827;
		public override uint MessageId => Id;
		public ObjectItem @object { get; set; }

		public StorageObjectUpdateMessage(ObjectItem @object)
		{
			this.@object = @object;
		}

		public StorageObjectUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			@object.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			@object = new ObjectItem();
			@object.Deserialize(reader);
		}

	}
}
