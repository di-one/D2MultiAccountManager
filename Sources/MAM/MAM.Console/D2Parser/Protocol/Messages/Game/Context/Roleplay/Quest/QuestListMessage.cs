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
	public class QuestListMessage : NetworkMessage
	{
		public const uint Id = 6337;
		public override uint MessageId => Id;
		public IEnumerable<ushort> finishedQuestsIds { get; set; }
		public IEnumerable<ushort> finishedQuestsCounts { get; set; }
		public IEnumerable<QuestActiveInformations> activeQuests { get; set; }
		public IEnumerable<ushort> reinitDoneQuestsIds { get; set; }

		public QuestListMessage(IEnumerable<ushort> finishedQuestsIds, IEnumerable<ushort> finishedQuestsCounts, IEnumerable<QuestActiveInformations> activeQuests, IEnumerable<ushort> reinitDoneQuestsIds)
		{
			this.finishedQuestsIds = finishedQuestsIds;
			this.finishedQuestsCounts = finishedQuestsCounts;
			this.activeQuests = activeQuests;
			this.reinitDoneQuestsIds = reinitDoneQuestsIds;
		}

		public QuestListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)finishedQuestsIds.Count());
			foreach (var objectToSend in finishedQuestsIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)finishedQuestsCounts.Count());
			foreach (var objectToSend in finishedQuestsCounts)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)activeQuests.Count());
			foreach (var objectToSend in activeQuests)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)reinitDoneQuestsIds.Count());
			foreach (var objectToSend in reinitDoneQuestsIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var finishedQuestsIdsCount = reader.ReadUShort();
			var finishedQuestsIds_ = new ushort[finishedQuestsIdsCount];
			for (var finishedQuestsIdsIndex = 0; finishedQuestsIdsIndex < finishedQuestsIdsCount; finishedQuestsIdsIndex++)
			{
				finishedQuestsIds_[finishedQuestsIdsIndex] = reader.ReadVarUShort();
			}
			finishedQuestsIds = finishedQuestsIds_;
			var finishedQuestsCountsCount = reader.ReadUShort();
			var finishedQuestsCounts_ = new ushort[finishedQuestsCountsCount];
			for (var finishedQuestsCountsIndex = 0; finishedQuestsCountsIndex < finishedQuestsCountsCount; finishedQuestsCountsIndex++)
			{
				finishedQuestsCounts_[finishedQuestsCountsIndex] = reader.ReadVarUShort();
			}
			finishedQuestsCounts = finishedQuestsCounts_;
			var activeQuestsCount = reader.ReadUShort();
			var activeQuests_ = new QuestActiveInformations[activeQuestsCount];
			for (var activeQuestsIndex = 0; activeQuestsIndex < activeQuestsCount; activeQuestsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<QuestActiveInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				activeQuests_[activeQuestsIndex] = objectToAdd;
			}
			activeQuests = activeQuests_;
			var reinitDoneQuestsIdsCount = reader.ReadUShort();
			var reinitDoneQuestsIds_ = new ushort[reinitDoneQuestsIdsCount];
			for (var reinitDoneQuestsIdsIndex = 0; reinitDoneQuestsIdsIndex < reinitDoneQuestsIdsCount; reinitDoneQuestsIdsIndex++)
			{
				reinitDoneQuestsIds_[reinitDoneQuestsIdsIndex] = reader.ReadVarUShort();
			}
			reinitDoneQuestsIds = reinitDoneQuestsIds_;
		}

	}
}
