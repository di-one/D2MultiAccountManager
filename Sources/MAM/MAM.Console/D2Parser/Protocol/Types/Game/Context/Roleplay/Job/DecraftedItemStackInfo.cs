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
	public class DecraftedItemStackInfo
	{
		public const short Id  = 1225;
		public virtual short TypeId => Id;
		public uint objectUID { get; set; }
		public float bonusMin { get; set; }
		public float bonusMax { get; set; }
		public IEnumerable<ushort> runesId { get; set; }
		public IEnumerable<uint> runesQty { get; set; }

		public DecraftedItemStackInfo(uint objectUID, float bonusMin, float bonusMax, IEnumerable<ushort> runesId, IEnumerable<uint> runesQty)
		{
			this.objectUID = objectUID;
			this.bonusMin = bonusMin;
			this.bonusMax = bonusMax;
			this.runesId = runesId;
			this.runesQty = runesQty;
		}

		public DecraftedItemStackInfo() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectUID);
			writer.WriteFloat(bonusMin);
			writer.WriteFloat(bonusMax);
			writer.WriteShort((short)runesId.Count());
			foreach (var objectToSend in runesId)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)runesQty.Count());
			foreach (var objectToSend in runesQty)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectUID = reader.ReadVarUInt();
			bonusMin = reader.ReadFloat();
			bonusMax = reader.ReadFloat();
			var runesIdCount = reader.ReadUShort();
			var runesId_ = new ushort[runesIdCount];
			for (var runesIdIndex = 0; runesIdIndex < runesIdCount; runesIdIndex++)
			{
				runesId_[runesIdIndex] = reader.ReadVarUShort();
			}
			runesId = runesId_;
			var runesQtyCount = reader.ReadUShort();
			var runesQty_ = new uint[runesQtyCount];
			for (var runesQtyIndex = 0; runesQtyIndex < runesQtyCount; runesQtyIndex++)
			{
				runesQty_[runesQtyIndex] = reader.ReadVarUInt();
			}
			runesQty = runesQty_;
		}

	}
}
