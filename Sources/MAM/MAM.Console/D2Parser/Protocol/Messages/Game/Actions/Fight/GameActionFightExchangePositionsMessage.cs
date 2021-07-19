namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightExchangePositionsMessage : AbstractGameActionMessage
	{
		public new const uint Id = 1851;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public short casterCellId { get; set; }
		public short targetCellId { get; set; }

		public GameActionFightExchangePositionsMessage(ushort actionId, double sourceId, double targetId, short casterCellId, short targetCellId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.casterCellId = casterCellId;
			this.targetCellId = targetCellId;
		}

		public GameActionFightExchangePositionsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteShort(casterCellId);
			writer.WriteShort(targetCellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			casterCellId = reader.ReadShort();
			targetCellId = reader.ReadShort();
		}

	}
}
