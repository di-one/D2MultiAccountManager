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
	public class ChatSmileyExtraPackListMessage : NetworkMessage
	{
		public const uint Id = 9998;
		public override uint MessageId => Id;
		public IEnumerable<byte> packIds { get; set; }

		public ChatSmileyExtraPackListMessage(IEnumerable<byte> packIds)
		{
			this.packIds = packIds;
		}

		public ChatSmileyExtraPackListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)packIds.Count());
			foreach (var objectToSend in packIds)
            {
				writer.WriteByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var packIdsCount = reader.ReadUShort();
			var packIds_ = new byte[packIdsCount];
			for (var packIdsIndex = 0; packIdsIndex < packIdsCount; packIdsIndex++)
			{
				packIds_[packIdsIndex] = reader.ReadByte();
			}
			packIds = packIds_;
		}

	}
}
