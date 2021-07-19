namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTeamMemberEntityInformation : FightTeamMemberInformations
	{
		public new const short Id = 4737;
		public override short TypeId => Id;
		public sbyte entityModelId { get; set; }
		public ushort level { get; set; }
		public double masterId { get; set; }

		public FightTeamMemberEntityInformation(double objectId, sbyte entityModelId, ushort level, double masterId)
		{
			this.objectId = objectId;
			this.entityModelId = entityModelId;
			this.level = level;
			this.masterId = masterId;
		}

		public FightTeamMemberEntityInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(entityModelId);
			writer.WriteVarUShort(level);
			writer.WriteDouble(masterId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			entityModelId = reader.ReadSByte();
			level = reader.ReadVarUShort();
			masterId = reader.ReadDouble();
		}

	}
}
