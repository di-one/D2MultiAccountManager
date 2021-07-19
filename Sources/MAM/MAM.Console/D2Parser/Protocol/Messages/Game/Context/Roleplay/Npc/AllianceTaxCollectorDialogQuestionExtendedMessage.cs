namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceTaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionExtendedMessage
	{
		public new const uint Id = 9640;
		public override uint MessageId => Id;
		public BasicNamedAllianceInformations alliance { get; set; }

		public AllianceTaxCollectorDialogQuestionExtendedMessage(BasicGuildInformations guildInfo, ushort maxPods, ushort prospecting, ushort wisdom, sbyte taxCollectorsCount, int taxCollectorAttack, ulong kamas, ulong experience, uint pods, ulong itemsValue, BasicNamedAllianceInformations alliance)
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
			this.alliance = alliance;
		}

		public AllianceTaxCollectorDialogQuestionExtendedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			alliance.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			alliance = new BasicNamedAllianceInformations();
			alliance.Deserialize(reader);
		}

	}
}
