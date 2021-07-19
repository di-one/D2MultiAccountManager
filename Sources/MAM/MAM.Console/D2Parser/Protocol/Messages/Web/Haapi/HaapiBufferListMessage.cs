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
	public class HaapiBufferListMessage : NetworkMessage
	{
		public const uint Id = 1794;
		public override uint MessageId => Id;
		public IEnumerable<BufferInformation> buffers { get; set; }

		public HaapiBufferListMessage(IEnumerable<BufferInformation> buffers)
		{
			this.buffers = buffers;
		}

		public HaapiBufferListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)buffers.Count());
			foreach (var objectToSend in buffers)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var buffersCount = reader.ReadUShort();
			var buffers_ = new BufferInformation[buffersCount];
			for (var buffersIndex = 0; buffersIndex < buffersCount; buffersIndex++)
			{
				var objectToAdd = new BufferInformation();
				objectToAdd.Deserialize(reader);
				buffers_[buffersIndex] = objectToAdd;
			}
			buffers = buffers_;
		}

	}
}
