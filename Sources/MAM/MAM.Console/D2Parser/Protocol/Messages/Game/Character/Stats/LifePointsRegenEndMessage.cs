namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LifePointsRegenEndMessage : UpdateLifePointsMessage
	{
		public new const uint Id = 2608;
		public override uint MessageId => Id;
		public uint lifePointsGained { get; set; }

		public LifePointsRegenEndMessage(uint lifePoints, uint maxLifePoints, uint lifePointsGained)
		{
			this.lifePoints = lifePoints;
			this.maxLifePoints = maxLifePoints;
			this.lifePointsGained = lifePointsGained;
		}

		public LifePointsRegenEndMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(lifePointsGained);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			lifePointsGained = reader.ReadVarUInt();
		}

	}
}
