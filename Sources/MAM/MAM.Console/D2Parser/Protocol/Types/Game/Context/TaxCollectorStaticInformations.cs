namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorStaticInformations
	{
		public const short Id  = 1042;
		public virtual short TypeId => Id;
		public ushort firstNameId { get; set; }
		public ushort lastNameId { get; set; }
		public GuildInformations guildIdentity { get; set; }
		public ulong callerId { get; set; }

		public TaxCollectorStaticInformations(ushort firstNameId, ushort lastNameId, GuildInformations guildIdentity, ulong callerId)
		{
			this.firstNameId = firstNameId;
			this.lastNameId = lastNameId;
			this.guildIdentity = guildIdentity;
			this.callerId = callerId;
		}

		public TaxCollectorStaticInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(firstNameId);
			writer.WriteVarUShort(lastNameId);
			guildIdentity.Serialize(writer);
			writer.WriteVarULong(callerId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			firstNameId = reader.ReadVarUShort();
			lastNameId = reader.ReadVarUShort();
			guildIdentity = new GuildInformations();
			guildIdentity.Deserialize(reader);
			callerId = reader.ReadVarULong();
		}

	}
}
