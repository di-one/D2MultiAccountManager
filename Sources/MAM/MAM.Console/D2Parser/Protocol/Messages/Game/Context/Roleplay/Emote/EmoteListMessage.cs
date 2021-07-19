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
	public class EmoteListMessage : NetworkMessage
	{
		public const uint Id = 1580;
		public override uint MessageId => Id;
		public IEnumerable<byte> emoteIds { get; set; }

		public EmoteListMessage(IEnumerable<byte> emoteIds)
		{
			this.emoteIds = emoteIds;
		}

		public EmoteListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)emoteIds.Count());
			foreach (var objectToSend in emoteIds)
            {
				writer.WriteByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var emoteIdsCount = reader.ReadUShort();
			var emoteIds_ = new byte[emoteIdsCount];
			for (var emoteIdsIndex = 0; emoteIdsIndex < emoteIdsCount; emoteIdsIndex++)
			{
				emoteIds_[emoteIdsIndex] = reader.ReadByte();
			}
			emoteIds = emoteIds_;
		}

	}
}
