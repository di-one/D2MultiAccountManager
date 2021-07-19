namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightUnmarkCellsMessage : AbstractGameActionMessage
	{
		public new const uint Id = 9652;
		public override uint MessageId => Id;
		public short markId { get; set; }

		public GameActionFightUnmarkCellsMessage(ushort actionId, double sourceId, short markId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.markId = markId;
		}

		public GameActionFightUnmarkCellsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(markId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			markId = reader.ReadShort();
		}

	}
}
