namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightReduceDamagesMessage : AbstractGameActionMessage
	{
		public new const uint Id = 2266;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public uint amount { get; set; }

		public GameActionFightReduceDamagesMessage(ushort actionId, double sourceId, double targetId, uint amount)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.amount = amount;
		}

		public GameActionFightReduceDamagesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteVarUInt(amount);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			amount = reader.ReadVarUInt();
		}

	}
}
