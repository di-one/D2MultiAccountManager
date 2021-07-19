namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AlliancePrismInformation : PrismInformation
	{
		public new const short Id = 4043;
		public override short TypeId => Id;
		public AllianceInformations alliance { get; set; }

		public AlliancePrismInformation(sbyte @typeId, sbyte state, int nextVulnerabilityDate, int placementDate, uint rewardTokenCount, AllianceInformations alliance)
		{
			this.@typeId = @typeId;
			this.state = state;
			this.nextVulnerabilityDate = nextVulnerabilityDate;
			this.placementDate = placementDate;
			this.rewardTokenCount = rewardTokenCount;
			this.alliance = alliance;
		}

		public AlliancePrismInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			alliance.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			alliance = new AllianceInformations();
			alliance.Deserialize(reader);
		}

	}
}
