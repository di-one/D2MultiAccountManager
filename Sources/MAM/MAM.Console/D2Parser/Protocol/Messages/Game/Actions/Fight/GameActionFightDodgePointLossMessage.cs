namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightDodgePointLossMessage : AbstractGameActionMessage
	{
		public new const uint Id = 6416;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public ushort amount { get; set; }

		public GameActionFightDodgePointLossMessage(ushort actionId, double sourceId, double targetId, ushort amount)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.amount = amount;
		}

		public GameActionFightDodgePointLossMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteVarUShort(amount);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			amount = reader.ReadVarUShort();
		}

	}
}
