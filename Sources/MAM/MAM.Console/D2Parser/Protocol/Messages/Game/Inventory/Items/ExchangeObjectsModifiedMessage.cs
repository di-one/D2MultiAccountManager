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
	public class ExchangeObjectsModifiedMessage : ExchangeObjectMessage
	{
		public new const uint Id = 899;
		public override uint MessageId => Id;
		public IEnumerable<ObjectItem> @object { get; set; }

		public ExchangeObjectsModifiedMessage(bool remote, IEnumerable<ObjectItem> @object)
		{
			this.remote = remote;
			this.@object = @object;
		}

		public ExchangeObjectsModifiedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)@object.Count());
			foreach (var objectToSend in @object)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var @objectCount = reader.ReadUShort();
			var @object_ = new ObjectItem[@objectCount];
			for (var @objectIndex = 0; @objectIndex < @objectCount; @objectIndex++)
			{
				var objectToAdd = new ObjectItem();
				objectToAdd.Deserialize(reader);
				@object_[@objectIndex] = objectToAdd;
			}
			@object = @object_;
		}

	}
}
