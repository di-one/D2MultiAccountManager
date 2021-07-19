namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightSlideMessage : AbstractGameActionMessage
	{
		public new const uint Id = 4704;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public short startCellId { get; set; }
		public short endCellId { get; set; }

		public GameActionFightSlideMessage(ushort actionId, double sourceId, double targetId, short startCellId, short endCellId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.startCellId = startCellId;
			this.endCellId = endCellId;
		}

		public GameActionFightSlideMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteShort(startCellId);
			writer.WriteShort(endCellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			startCellId = reader.ReadShort();
			endCellId = reader.ReadShort();
		}

	}
}
