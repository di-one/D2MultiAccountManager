namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightThrowCharacterMessage : AbstractGameActionMessage
	{
		public new const uint Id = 4198;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public short cellId { get; set; }

		public GameActionFightThrowCharacterMessage(ushort actionId, double sourceId, double targetId, short cellId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.cellId = cellId;
		}

		public GameActionFightThrowCharacterMessage() { }

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
