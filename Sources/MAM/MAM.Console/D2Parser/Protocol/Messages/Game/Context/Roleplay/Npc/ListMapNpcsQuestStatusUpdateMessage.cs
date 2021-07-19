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
	public class ListMapNpcsQuestStatusUpdateMessage : NetworkMessage
	{
		public const uint Id = 2580;
		public override uint MessageId => Id;
		public IEnumerable<MapNpcQuestInfo> mapInfo { get; set; }

		public ListMapNpcsQuestStatusUpdateMessage(IEnumerable<MapNpcQuestInfo> mapInfo)
		{
			this.mapInfo = mapInfo;
		}

		public ListMapNpcsQuestStatusUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)mapInfo.Count());
			foreach (var objectToSend in mapInfo)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var mapInfoCount = reader.ReadUShort();
			var mapInfo_ = new MapNpcQuestInfo[mapInfoCount];
			for (var mapInfoIndex = 0; mapInfoIndex < mapInfoCount; mapInfoIndex++)
			{
				var objectToAdd = new MapNpcQuestInfo();
				objectToAdd.Deserialize(reader);
				mapInfo_[mapInfoIndex] = objectToAdd;
			}
			mapInfo = mapInfo_;
		}

	}
}
