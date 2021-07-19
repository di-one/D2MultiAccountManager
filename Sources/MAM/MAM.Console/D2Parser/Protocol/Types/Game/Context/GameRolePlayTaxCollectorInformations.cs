namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
	{
		public new const short Id = 1656;
		public override short TypeId => Id;
		public TaxCollectorStaticInformations identification { get; set; }
		public byte guildLevel { get; set; }
		public int taxCollectorAttack { get; set; }

		public GameRolePlayTaxCollectorInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, TaxCollectorStaticInformations identification, byte guildLevel, int taxCollectorAttack)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.identification = identification;
			this.guildLevel = guildLevel;
			this.taxCollectorAttack = taxCollectorAttack;
		}

		public GameRolePlayTaxCollectorInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(identification.TypeId);
			identification.Serialize(writer);
			writer.WriteByte(guildLevel);
			writer.WriteInt(taxCollectorAttack);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			identification = ProtocolTypeManager.GetInstance<TaxCollectorStaticInformations>(reader.ReadShort());
			identification.Deserialize(reader);
			guildLevel = reader.ReadByte();
			taxCollectorAttack = reader.ReadInt();
		}

	}
}
