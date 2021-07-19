namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTeamMemberTaxCollectorInformations : FightTeamMemberInformations
	{
		public new const short Id = 9221;
		public override short TypeId => Id;
		public ushort firstNameId { get; set; }
		public ushort lastNameId { get; set; }
		public byte level { get; set; }
		public uint guildId { get; set; }
		public double uid { get; set; }

		public FightTeamMemberTaxCollectorInformations(double objectId, ushort firstNameId, ushort lastNameId, byte level, uint guildId, double uid)
		{
			this.objectId = objectId;
			this.firstNameId = firstNameId;
			this.lastNameId = lastNameId;
			this.level = level;
			this.guildId = guildId;
			this.uid = uid;
		}

		public FightTeamMemberTaxCollectorInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(firstNameId);
			writer.WriteVarUShort(lastNameId);
			writer.WriteByte(level);
			writer.WriteVarUInt(guildId);
			writer.WriteDouble(uid);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			firstNameId = reader.ReadVarUShort();
			lastNameId = reader.ReadVarUShort();
			level = reader.ReadByte();
			guildId = reader.ReadVarUInt();
			uid = reader.ReadDouble();
		}

	}
}
