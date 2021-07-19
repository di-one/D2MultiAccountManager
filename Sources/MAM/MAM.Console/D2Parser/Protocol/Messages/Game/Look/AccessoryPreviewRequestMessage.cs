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
	public class AccessoryPreviewRequestMessage : NetworkMessage
	{
		public const uint Id = 8434;
		public override uint MessageId => Id;
		public IEnumerable<ushort> genericId { get; set; }

		public AccessoryPreviewRequestMessage(IEnumerable<ushort> genericId)
		{
			this.genericId = genericId;
		}

		public AccessoryPreviewRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)genericId.Count());
			foreach (var objectToSend in genericId)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var genericIdCount = reader.ReadUShort();
			var genericId_ = new ushort[genericIdCount];
			for (var genericIdIndex = 0; genericIdIndex < genericIdCount; genericIdIndex++)
			{
				genericId_[genericIdIndex] = reader.ReadVarUShort();
			}
			genericId = genericId_;
		}

	}
}
