namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class UpdateLifePointsMessage : NetworkMessage
	{
		public const uint Id = 9545;
		public override uint MessageId => Id;
		public uint lifePoints { get; set; }
		public uint maxLifePoints { get; set; }

		public UpdateLifePointsMessage(uint lifePoints, uint maxLifePoints)
		{
			this.lifePoints = lifePoints;
			this.maxLifePoints = maxLifePoints;
		}

		public UpdateLifePointsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(lifePoints);
			writer.WriteVarUInt(maxLifePoints);
		}

		public override void Deserialize(IDataReader reader)
		{
			lifePoints = reader.ReadVarUInt();
			maxLifePoints = reader.ReadVarUInt();
		}

	}
}
