namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightDropCharacterMessage : AbstractGameActionMessage
	{
		public new const uint Id = 9345;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public short cellId { get; set; }

		public GameActionFightDropCharacterMessage(ushort actionId, double sourceId, double targetId, short cellId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.cellId = cellId;
		}

		public GameActionFightDropCharacterMessage() { }

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
