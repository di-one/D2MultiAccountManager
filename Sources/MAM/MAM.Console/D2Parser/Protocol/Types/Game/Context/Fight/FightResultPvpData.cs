namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightResultPvpData : FightResultAdditionalData
	{
		public new const short Id = 4466;
		public override short TypeId => Id;
		public byte grade { get; set; }
		public ushort minHonorForGrade { get; set; }
		public ushort maxHonorForGrade { get; set; }
		public ushort honor { get; set; }
		public short honorDelta { get; set; }

		public FightResultPvpData(byte grade, ushort minHonorForGrade, ushort maxHonorForGrade, ushort honor, short honorDelta)
		{
			this.grade = grade;
			this.minHonorForGrade = minHonorForGrade;
			this.maxHonorForGrade = maxHonorForGrade;
			this.honor = honor;
			this.honorDelta = honorDelta;
		}

		public FightResultPvpData() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteByte(grade);
			writer.WriteVarUShort(minHonorForGrade);
			writer.WriteVarUShort(maxHonorForGrade);
			writer.WriteVarUShort(honor);
			writer.WriteVarShort(honorDelta);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			grade = reader.ReadByte();
			minHonorForGrade = reader.ReadVarUShort();
			maxHonorForGrade = reader.ReadVarUShort();
			honor = reader.ReadVarUShort();
			honorDelta = reader.ReadVarShort();
		}

	}
}
