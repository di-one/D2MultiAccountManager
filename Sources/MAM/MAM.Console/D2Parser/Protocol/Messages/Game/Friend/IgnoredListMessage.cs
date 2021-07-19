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
	public class IgnoredListMessage : NetworkMessage
	{
		public const uint Id = 4183;
		public override uint MessageId => Id;
		public IEnumerable<IgnoredInformations> ignoredList { get; set; }

		public IgnoredListMessage(IEnumerable<IgnoredInformations> ignoredList)
		{
			this.ignoredList = ignoredList;
		}

		public IgnoredListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)ignoredList.Count());
			foreach (var objectToSend in ignoredList)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var ignoredListCount = reader.ReadUShort();
			var ignoredList_ = new IgnoredInformations[ignoredListCount];
			for (var ignoredListIndex = 0; ignoredListIndex < ignoredListCount; ignoredListIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				ignoredList_[ignoredListIndex] = objectToAdd;
			}
			ignoredList = ignoredList_;
		}

	}
}
