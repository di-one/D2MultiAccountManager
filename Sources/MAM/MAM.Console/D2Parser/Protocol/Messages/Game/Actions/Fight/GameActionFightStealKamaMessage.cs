namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightStealKamaMessage : AbstractGameActionMessage
	{
		public new const uint Id = 7468;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public ulong amount { get; set; }

		public GameActionFightStealKamaMessage(ushort actionId, double sourceId, double targetId, ulong amount)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.amount = amount;
		}

		public GameActionFightStealKamaMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteVarULong(amount);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			amount = reader.ReadVarULong();
		}

	}
}
