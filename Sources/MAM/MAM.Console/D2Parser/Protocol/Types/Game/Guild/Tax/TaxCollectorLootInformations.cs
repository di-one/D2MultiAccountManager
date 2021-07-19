namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorLootInformations : TaxCollectorComplementaryInformations
	{
		public new const short Id = 9341;
		public override short TypeId => Id;
		public ulong kamas { get; set; }
		public ulong experience { get; set; }
		public uint pods { get; set; }
		public ulong itemsValue { get; set; }

		public TaxCollectorLootInformations(ulong kamas, ulong experience, uint pods, ulong itemsValue)
		{
			this.kamas = kamas;
			this.experience = experience;
			this.pods = pods;
			this.itemsValue = itemsValue;
		}

		public TaxCollectorLootInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(kamas);
			writer.WriteVarULong(experience);
			writer.WriteVarUInt(pods);
			writer.WriteVarULong(itemsValue);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			kamas = reader.ReadVarULong();
			experience = reader.ReadVarULong();
			pods = reader.ReadVarUInt();
			itemsValue = reader.ReadVarULong();
		}

	}
}
