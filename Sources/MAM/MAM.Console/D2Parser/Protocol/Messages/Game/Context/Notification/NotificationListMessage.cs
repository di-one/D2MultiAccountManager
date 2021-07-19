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
	public class NotificationListMessage : NetworkMessage
	{
		public const uint Id = 6961;
		public override uint MessageId => Id;
		public IEnumerable<int> flags { get; set; }

		public NotificationListMessage(IEnumerable<int> flags)
		{
			this.flags = flags;
		}

		public NotificationListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)flags.Count());
			foreach (var objectToSend in flags)
            {
				writer.WriteVarInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var flagsCount = reader.ReadUShort();
			var flags_ = new int[flagsCount];
			for (var flagsIndex = 0; flagsIndex < flagsCount; flagsIndex++)
			{
				flags_[flagsIndex] = reader.ReadVarInt();
			}
			flags = flags_;
		}

	}
}
