namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InventoryWeightMessage : NetworkMessage
	{
		public const uint Id = 7128;
		public override uint MessageId => Id;
		public uint inventoryWeight { get; set; }
		public uint shopWeight { get; set; }
		public uint weightMax { get; set; }

		public InventoryWeightMessage(uint inventoryWeight, uint shopWeight, uint weightMax)
		{
			this.inventoryWeight = inventoryWeight;
			this.shopWeight = shopWeight;
			this.weightMax = weightMax;
		}

		public InventoryWeightMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(inventoryWeight);
			writer.WriteVarUInt(shopWeight);
			writer.WriteVarUInt(weightMax);
		}

		public override void Deserialize(IDataReader reader)
		{
			inventoryWeight = reader.ReadVarUInt();
			shopWeight = reader.ReadVarUInt();
			weightMax = reader.ReadVarUInt();
		}

	}
}
