namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class QuestObjectiveInformationsWithCompletion : QuestObjectiveInformations
	{
		public new const short Id = 9237;
		public override short TypeId => Id;
		public ushort curCompletion { get; set; }
		public ushort maxCompletion { get; set; }

		public QuestObjectiveInformationsWithCompletion(ushort objectiveId, bool objectiveStatus, IEnumerable<string> dialogParams, ushort curCompletion, ushort maxCompletion)
		{
			this.objectiveId = objectiveId;
			this.objectiveStatus = objectiveStatus;
			this.dialogParams = dialogParams;
			this.curCompletion = curCompletion;
			this.maxCompletion = maxCompletion;
		}

		public QuestObjectiveInformationsWithCompletion() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(curCompletion);
			writer.WriteVarUShort(maxCompletion);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			curCompletion = reader.ReadVarUShort();
			maxCompletion = reader.ReadVarUShort();
		}

	}
}
