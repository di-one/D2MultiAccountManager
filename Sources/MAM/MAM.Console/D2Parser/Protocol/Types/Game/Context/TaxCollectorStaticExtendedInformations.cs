namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorStaticExtendedInformations : TaxCollectorStaticInformations
	{
		public new const short Id = 6146;
		public override short TypeId => Id;
		public AllianceInformations allianceIdentity { get; set; }

		public TaxCollectorStaticExtendedInformations(ushort firstNameId, ushort lastNameId, GuildInformations guildIdentity, ulong callerId, AllianceInformations allianceIdentity)
		{
			this.firstNameId = firstNameId;
			this.lastNameId = lastNameId;
			this.guildIdentity = guildIdentity;
			this.callerId = callerId;
			this.allianceIdentity = allianceIdentity;
		}

		public TaxCollectorStaticExtendedInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			allianceIdentity.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			allianceIdentity = new AllianceInformations();
			allianceIdentity.Deserialize(reader);
		}

	}
}
