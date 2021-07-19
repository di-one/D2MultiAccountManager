namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class QuestStepInfoMessage : NetworkMessage
	{
		public const uint Id = 1124;
		public override uint MessageId => Id;
		public QuestActiveInformations infos { get; set; }

		public QuestStepInfoMessage(QuestActiveInformations infos)
		{
			this.infos = infos;
		}

		public QuestStepInfoMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(infos.TypeId);
			infos.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			infos = ProtocolTypeManager.GetInstance<QuestActiveInformations>(reader.ReadShort());
			infos.Deserialize(reader);
		}

	}
}
