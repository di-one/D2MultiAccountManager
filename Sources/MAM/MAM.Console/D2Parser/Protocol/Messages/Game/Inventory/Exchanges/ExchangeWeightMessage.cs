namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeWeightMessage : NetworkMessage
	{
		public const uint Id = 6886;
		public override uint MessageId => Id;
		public uint currentWeight { get; set; }
		public uint maxWeight { get; set; }

		public ExchangeWeightMessage(uint currentWeight, uint maxWeight)
		{
			this.currentWeight = currentWeight;
			this.maxWeight = maxWeight;
		}

		public ExchangeWeightMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(currentWeight);
			writer.WriteVarUInt(maxWeight);
		}

		public override void Deserialize(IDataReader reader)
		{
			currentWeight = reader.ReadVarUInt();
			maxWeight = reader.ReadVarUInt();
		}

	}
}
