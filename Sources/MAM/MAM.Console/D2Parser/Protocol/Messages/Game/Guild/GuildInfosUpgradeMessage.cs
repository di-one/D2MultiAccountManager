namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInfosUpgradeMessage : NetworkMessage
	{
		public const uint Id = 6746;
		public override uint MessageId => Id;
		public sbyte maxTaxCollectorsCount { get; set; }
		public sbyte taxCollectorsCount { get; set; }
		public ushort taxCollectorLifePoints { get; set; }
		public ushort taxCollectorDamagesBonuses { get; set; }
		public ushort taxCollectorPods { get; set; }
		public ushort taxCollectorProspecting { get; set; }
		public ushort taxCollectorWisdom { get; set; }
		public ushort boostPoints { get; set; }
		public IEnumerable<ushort> spellId { get; set; }
		public IEnumerable<short> spellLevel { get; set; }

		public GuildInfosUpgradeMessage(sbyte maxTaxCollectorsCount, sbyte taxCollectorsCount, ushort taxCollectorLifePoints, ushort taxCollectorDamagesBonuses, ushort taxCollectorPods, ushort taxCollectorProspecting, ushort taxCollectorWisdom, ushort boostPoints, IEnumerable<ushort> spellId, IEnumerable<short> spellLevel)
		{
			this.maxTaxCollectorsCount = maxTaxCollectorsCount;
			this.taxCollectorsCount = taxCollectorsCount;
			this.taxCollectorLifePoints = taxCollectorLifePoints;
			this.taxCollectorDamagesBonuses = taxCollectorDamagesBonuses;
			this.taxCollectorPods = taxCollectorPods;
			this.taxCollectorProspecting = taxCollectorProspecting;
			this.taxCollectorWisdom = taxCollectorWisdom;
			this.boostPoints = boostPoints;
			this.spellId = spellId;
			this.spellLevel = spellLevel;
		}

		public GuildInfosUpgradeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(maxTaxCollectorsCount);
			writer.WriteSByte(taxCollectorsCount);
			writer.WriteVarUShort(taxCollectorLifePoints);
			writer.WriteVarUShort(taxCollectorDamagesBonuses);
			writer.WriteVarUShort(taxCollectorPods);
			writer.WriteVarUShort(taxCollectorProspecting);
			writer.WriteVarUShort(taxCollectorWisdom);
			writer.WriteVarUShort(boostPoints);
			writer.WriteShort((short)spellId.Count());
			foreach (var objectToSend in spellId)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)spellLevel.Count());
			foreach (var objectToSend in spellLevel)
            {
				writer.WriteShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			maxTaxCollectorsCount = reader.ReadSByte();
			taxCollectorsCount = reader.ReadSByte();
			taxCollectorLifePoints = reader.ReadVarUShort();
			taxCollectorDamagesBonuses = reader.ReadVarUShort();
			taxCollectorPods = reader.ReadVarUShort();
			taxCollectorProspecting = reader.ReadVarUShort();
			taxCollectorWisdom = reader.ReadVarUShort();
			boostPoints = reader.ReadVarUShort();
			var spellIdCount = reader.ReadUShort();
			var spellId_ = new ushort[spellIdCount];
			for (var spellIdIndex = 0; spellIdIndex < spellIdCount; spellIdIndex++)
			{
				spellId_[spellIdIndex] = reader.ReadVarUShort();
			}
			spellId = spellId_;
			var spellLevelCount = reader.ReadUShort();
			var spellLevel_ = new short[spellLevelCount];
			for (var spellLevelIndex = 0; spellLevelIndex < spellLevelCount; spellLevelIndex++)
			{
				spellLevel_[spellLevelIndex] = reader.ReadShort();
			}
			spellLevel = spellLevel_;
		}

	}
}
