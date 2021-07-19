namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightLifeAndShieldPointsLostMessage : GameActionFightLifePointsLostMessage
	{
		public new const uint Id = 6688;
		public override uint MessageId => Id;
		public ushort shieldLoss { get; set; }

		public GameActionFightLifeAndShieldPointsLostMessage(ushort actionId, double sourceId, double targetId, uint loss, uint permanentDamages, int elementId, ushort shieldLoss)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.loss = loss;
			this.permanentDamages = permanentDamages;
			this.elementId = elementId;
			this.shieldLoss = shieldLoss;
		}

		public GameActionFightLifeAndShieldPointsLostMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(shieldLoss);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			shieldLoss = reader.ReadVarUShort();
		}

	}
}
