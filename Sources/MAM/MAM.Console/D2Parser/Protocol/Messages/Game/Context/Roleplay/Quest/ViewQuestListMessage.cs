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
	public class ViewQuestListMessage : QuestListMessage
	{
		public new const uint Id = 5319;
		public override uint MessageId => Id;

		public ViewQuestListMessage(IEnumerable<ushort> finishedQuestsIds, IEnumerable<ushort> finishedQuestsCounts, IEnumerable<QuestActiveInformations> activeQuests, IEnumerable<ushort> reinitDoneQuestsIds)
		{
			this.finishedQuestsIds = finishedQuestsIds;
			this.finishedQuestsCounts = finishedQuestsCounts;
			this.activeQuests = activeQuests;
			this.reinitDoneQuestsIds = reinitDoneQuestsIds;
		}

		public ViewQuestListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
