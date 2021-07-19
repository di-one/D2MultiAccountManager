namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangePodsModifiedMessage : ExchangeObjectMessage
	{
		public new const uint Id = 814;
		public override uint MessageId => Id;
		public uint currentWeight { get; set; }
		public uint maxWeight { get; set; }

		public ExchangePodsModifiedMessage(bool remote, uint currentWeight, uint maxWeight)
		{
			this.remote = remote;
			this.currentWeight = currentWeight;
			this.maxWeight = maxWeight;
		}

		public ExchangePodsModifiedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(currentWeight);
			writer.WriteVarUInt(maxWeight);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			currentWeight = reader.ReadVarUInt();
			maxWeight = reader.ReadVarUInt();
		}

	}
}
