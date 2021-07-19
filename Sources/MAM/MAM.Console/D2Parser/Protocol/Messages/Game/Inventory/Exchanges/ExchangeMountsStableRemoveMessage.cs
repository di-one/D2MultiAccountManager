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
	public class ExchangeMountsStableRemoveMessage : NetworkMessage
	{
		public const uint Id = 1512;
		public override uint MessageId => Id;
		public IEnumerable<int> mountsId { get; set; }

		public ExchangeMountsStableRemoveMessage(IEnumerable<int> mountsId)
		{
			this.mountsId = mountsId;
		}

		public ExchangeMountsStableRemoveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)mountsId.Count());
			foreach (var objectToSend in mountsId)
            {
				writer.WriteVarInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var mountsIdCount = reader.ReadUShort();
			var mountsId_ = new int[mountsIdCount];
			for (var mountsIdIndex = 0; mountsIdIndex < mountsIdCount; mountsIdIndex++)
			{
				mountsId_[mountsIdIndex] = reader.ReadVarInt();
			}
			mountsId = mountsId_;
		}

	}
}
