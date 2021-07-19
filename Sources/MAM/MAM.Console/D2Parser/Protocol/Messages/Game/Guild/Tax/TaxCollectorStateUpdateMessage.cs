namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorStateUpdateMessage : NetworkMessage
	{
		public const uint Id = 7245;
		public override uint MessageId => Id;
		public double uniqueId { get; set; }
		public sbyte state { get; set; }

		public TaxCollectorStateUpdateMessage(double uniqueId, sbyte state)
		{
			this.uniqueId = uniqueId;
			this.state = state;
		}

		public TaxCollectorStateUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(uniqueId);
			writer.WriteSByte(state);
		}

		public override void Deserialize(IDataReader reader)
		{
			uniqueId = reader.ReadDouble();
			state = reader.ReadSByte();
		}

	}
}
