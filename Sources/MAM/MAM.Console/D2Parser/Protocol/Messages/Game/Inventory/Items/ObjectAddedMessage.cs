namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectAddedMessage : NetworkMessage
	{
		public const uint Id = 8476;
		public override uint MessageId => Id;
		public ObjectItem @object { get; set; }
		public sbyte origin { get; set; }

		public ObjectAddedMessage(ObjectItem @object, sbyte origin)
		{
			this.@object = @object;
			this.origin = origin;
		}

		public ObjectAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			@object.Serialize(writer);
			writer.WriteSByte(origin);
		}

		public override void Deserialize(IDataReader reader)
		{
			@object = new ObjectItem();
			@object.Deserialize(reader);
			origin = reader.ReadSByte();
		}

	}
}
