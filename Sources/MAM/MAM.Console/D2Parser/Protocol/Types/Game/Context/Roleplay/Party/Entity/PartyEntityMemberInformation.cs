namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyEntityMemberInformation : PartyEntityBaseInformation
	{
		public new const short Id = 3958;
		public override short TypeId => Id;
		public ushort initiative { get; set; }
		public uint lifePoints { get; set; }
		public uint maxLifePoints { get; set; }
		public ushort prospecting { get; set; }
		public byte regenRate { get; set; }

		public PartyEntityMemberInformation(sbyte indexId, sbyte entityModelId, EntityLook entityLook, ushort initiative, uint lifePoints, uint maxLifePoints, ushort prospecting, byte regenRate)
		{
			this.indexId = indexId;
			this.entityModelId = entityModelId;
			this.entityLook = entityLook;
			this.initiative = initiative;
			this.lifePoints = lifePoints;
			this.maxLifePoints = maxLifePoints;
			this.prospecting = prospecting;
			this.regenRate = regenRate;
		}

		public PartyEntityMemberInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(initiative);
			writer.WriteVarUInt(lifePoints);
			writer.WriteVarUInt(maxLifePoints);
			writer.WriteVarUShort(prospecting);
			writer.WriteByte(regenRate);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			initiative = reader.ReadVarUShort();
			lifePoints = reader.ReadVarUInt();
			maxLifePoints = reader.ReadVarUInt();
			prospecting = reader.ReadVarUShort();
			regenRate = reader.ReadByte();
		}

	}
}
