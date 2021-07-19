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
	public class QuestObjectiveInformations
	{
		public const short Id  = 1560;
		public virtual short TypeId => Id;
		public ushort objectiveId { get; set; }
		public bool objectiveStatus { get; set; }
		public IEnumerable<string> dialogParams { get; set; }

		public QuestObjectiveInformations(ushort objectiveId, bool objectiveStatus, IEnumerable<string> dialogParams)
		{
			this.objectiveId = objectiveId;
			this.objectiveStatus = objectiveStatus;
			this.dialogParams = dialogParams;
		}

		public QuestObjectiveInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objectiveId);
			writer.WriteBoolean(objectiveStatus);
			writer.WriteShort((short)dialogParams.Count());
			foreach (var objectToSend in dialogParams)
            {
				writer.WriteUTF(objectToSend);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectiveId = reader.ReadVarUShort();
			objectiveStatus = reader.ReadBoolean();
			var dialogParamsCount = reader.ReadUShort();
			var dialogParams_ = new string[dialogParamsCount];
			for (var dialogParamsIndex = 0; dialogParamsIndex < dialogParamsCount; dialogParamsIndex++)
			{
				dialogParams_[dialogParamsIndex] = reader.ReadUTF();
			}
			dialogParams = dialogParams_;
		}

	}
}
