namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightInvisibleDetectedMessage : AbstractGameActionMessage
	{
		public new const uint Id = 8639;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public short cellId { get; set; }

		public GameActionFightInvisibleDetectedMessage(ushort actionId, double sourceId, double targetId, short cellId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.cellId = cellId;
		}

		public GameActionFightInvisibleDetectedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteShort(cellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			cellId = reader.ReadShort();
		}

	}
}
