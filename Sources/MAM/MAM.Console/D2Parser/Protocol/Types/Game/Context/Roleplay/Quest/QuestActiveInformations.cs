namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class QuestActiveInformations
	{
		public const short Id  = 3840;
		public virtual short TypeId => Id;
		public ushort questId { get; set; }

		public QuestActiveInformations(ushort questId)
		{
			this.questId = questId;
		}

		public QuestActiveInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(questId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			questId = reader.ReadVarUShort();
		}

	}
}
