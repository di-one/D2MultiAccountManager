namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
	{
		public new const uint Id = 6454;
		public override uint MessageId => Id;
		public ushort maxPods { get; set; }
		public ushort prospecting { get; set; }
		public ushort wisdom { get; set; }
		public sbyte taxCollectorsCount { get; set; }
		public int taxCollectorAttack { get; set; }
		public ulong kamas { get; set; }
		public ulong experience { get; set; }
		public uint pods { get; set; }
		public ulong itemsValue { get; set; }

		public TaxCollectorDialogQuestionExtendedMessage(BasicGuildInformations guildInfo, ushort maxPods, ushort prospecting, ushort wisdom, sbyte taxCollectorsCount, int taxCollectorAttack, ulong kamas, ulong experience, uint pods, ulong itemsValue)
		{
			this.guildInfo = guildInfo;
			this.maxPods = maxPods;
			this.prospecting = prospecting;
			this.wisdom = wisdom;
			this.taxCollectorsCount = taxCollectorsCount;
			this.taxCollectorAttack = taxCollectorAttack;
			this.kamas = kamas;
			this.experience = experience;
			this.pods = pods;
			this.itemsValue = itemsValue;
		}

		public TaxCollectorDialogQuestionExtendedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(maxPods);
			writer.WriteVarUShort(prospecting);
			writer.WriteVarUShort(wisdom);
			writer.WriteSByte(taxCollectorsCount);
			writer.WriteInt(taxCollectorAttack);
			writer.WriteVarULong(kamas);
			writer.WriteVarULong(experience);
			writer.WriteVarUInt(pods);
			writer.WriteVarULong(itemsValue);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			maxPods = reader.ReadVarUShort();
			prospecting = reader.ReadVarUShort();
			wisdom = reader.ReadVarUShort();
			taxCollectorsCount = reader.ReadSByte();
			taxCollectorAttack = reader.ReadInt();
			kamas = reader.ReadVarULong();
			experience = reader.ReadVarULong();
			pods = reader.ReadVarUInt();
			itemsValue = reader.ReadVarULong();
		}

	}
}
