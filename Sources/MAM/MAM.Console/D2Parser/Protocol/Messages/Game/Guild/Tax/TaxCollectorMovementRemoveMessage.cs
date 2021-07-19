namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorMovementRemoveMessage : NetworkMessage
	{
		public const uint Id = 778;
		public override uint MessageId => Id;
		public double collectorId { get; set; }

		public TaxCollectorMovementRemoveMessage(double collectorId)
		{
			this.collectorId = collectorId;
		}

		public TaxCollectorMovementRemoveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(collectorId);
		}

		public override void Deserialize(IDataReader reader)
		{
			collectorId = reader.ReadDouble();
		}

	}
}
