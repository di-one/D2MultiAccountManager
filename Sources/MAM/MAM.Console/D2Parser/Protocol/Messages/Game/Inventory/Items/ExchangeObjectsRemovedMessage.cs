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
	public class ExchangeObjectsRemovedMessage : ExchangeObjectMessage
	{
		public new const uint Id = 9984;
		public override uint MessageId => Id;
		public IEnumerable<uint> objectUID { get; set; }

		public ExchangeObjectsRemovedMessage(bool remote, IEnumerable<uint> objectUID)
		{
			this.remote = remote;
			this.objectUID = objectUID;
		}

		public ExchangeObjectsRemovedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)objectUID.Count());
			foreach (var objectToSend in objectUID)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var objectUIDCount = reader.ReadUShort();
			var objectUID_ = new uint[objectUIDCount];
			for (var objectUIDIndex = 0; objectUIDIndex < objectUIDCount; objectUIDIndex++)
			{
				objectUID_[objectUIDIndex] = reader.ReadVarUInt();
			}
			objectUID = objectUID_;
		}

	}
}
