namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SellerBuyerDescriptor
	{
		public const short Id  = 5463;
		public virtual short TypeId => Id;
		public IEnumerable<uint> quantities { get; set; }
		public IEnumerable<uint> types { get; set; }
		public float taxPercentage { get; set; }
		public float taxModificationPercentage { get; set; }
		public byte maxItemLevel { get; set; }
		public uint maxItemPerAccount { get; set; }
		public int npcContextualId { get; set; }
		public ushort unsoldDelay { get; set; }

		public SellerBuyerDescriptor(IEnumerable<uint> quantities, IEnumerable<uint> types, float taxPercentage, float taxModificationPercentage, byte maxItemLevel, uint maxItemPerAccount, int npcContextualId, ushort unsoldDelay)
		{
			this.quantities = quantities;
			this.types = types;
			this.taxPercentage = taxPercentage;
			this.taxModificationPercentage = taxModificationPercentage;
			this.maxItemLevel = maxItemLevel;
			this.maxItemPerAccount = maxItemPerAccount;
			this.npcContextualId = npcContextualId;
			this.unsoldDelay = unsoldDelay;
		}

		public SellerBuyerDescriptor() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)quantities.Count());
			foreach (var objectToSend in quantities)
            {
				writer.WriteVarUInt(objectToSend);
			}
			writer.WriteShort((short)types.Count());
			foreach (var objectToSend in types)
            {
				writer.WriteVarUInt(objectToSend);
			}
			writer.WriteFloat(taxPercentage);
			writer.WriteFloat(taxModificationPercentage);
			writer.WriteByte(maxItemLevel);
			writer.WriteVarUInt(maxItemPerAccount);
			writer.WriteInt(npcContextualId);
			writer.WriteVarUShort(unsoldDelay);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var quantitiesCount = reader.ReadUShort();
			var quantities_ = new uint[quantitiesCount];
			for (var quantitiesIndex = 0; quantitiesIndex < quantitiesCount; quantitiesIndex++)
			{
				quantities_[quantitiesIndex] = reader.ReadVarUInt();
			}
			quantities = quantities_;
			var typesCount = reader.ReadUShort();
			var types_ = new uint[typesCount];
			for (var typesIndex = 0; typesIndex < typesCount; typesIndex++)
			{
				types_[typesIndex] = reader.ReadVarUInt();
			}
			types = types_;
			taxPercentage = reader.ReadFloat();
			taxModificationPercentage = reader.ReadFloat();
			maxItemLevel = reader.ReadByte();
			maxItemPerAccount = reader.ReadVarUInt();
			npcContextualId = reader.ReadInt();
			unsoldDelay = reader.ReadVarUShort();
		}

	}
}
