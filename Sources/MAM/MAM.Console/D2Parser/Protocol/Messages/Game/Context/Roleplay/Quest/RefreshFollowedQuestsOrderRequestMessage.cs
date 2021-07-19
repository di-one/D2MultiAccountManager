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
	public class RefreshFollowedQuestsOrderRequestMessage : NetworkMessage
	{
		public const uint Id = 677;
		public override uint MessageId => Id;
		public IEnumerable<ushort> quests { get; set; }

		public RefreshFollowedQuestsOrderRequestMessage(IEnumerable<ushort> quests)
		{
			this.quests = quests;
		}

		public RefreshFollowedQuestsOrderRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)quests.Count());
			foreach (var objectToSend in quests)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var questsCount = reader.ReadUShort();
			var quests_ = new ushort[questsCount];
			for (var questsIndex = 0; questsIndex < questsCount; questsIndex++)
			{
				quests_[questsIndex] = reader.ReadVarUShort();
			}
			quests = quests_;
		}

	}
}
