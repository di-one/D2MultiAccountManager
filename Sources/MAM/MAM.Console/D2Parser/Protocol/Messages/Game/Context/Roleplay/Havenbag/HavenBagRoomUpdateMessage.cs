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
	public class HavenBagRoomUpdateMessage : NetworkMessage
	{
		public const uint Id = 1683;
		public override uint MessageId => Id;
		public sbyte action { get; set; }
		public IEnumerable<HavenBagRoomPreviewInformation> roomsPreview { get; set; }

		public HavenBagRoomUpdateMessage(sbyte action, IEnumerable<HavenBagRoomPreviewInformation> roomsPreview)
		{
			this.action = action;
			this.roomsPreview = roomsPreview;
		}

		public HavenBagRoomUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(action);
			writer.WriteShort((short)roomsPreview.Count());
			foreach (var objectToSend in roomsPreview)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			action = reader.ReadSByte();
			var roomsPreviewCount = reader.ReadUShort();
			var roomsPreview_ = new HavenBagRoomPreviewInformation[roomsPreviewCount];
			for (var roomsPreviewIndex = 0; roomsPreviewIndex < roomsPreviewCount; roomsPreviewIndex++)
			{
				var objectToAdd = new HavenBagRoomPreviewInformation();
				objectToAdd.Deserialize(reader);
				roomsPreview_[roomsPreviewIndex] = objectToAdd;
			}
			roomsPreview = roomsPreview_;
		}

	}
}
