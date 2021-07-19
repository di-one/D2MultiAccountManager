namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ActorExtendedAlignmentInformations : ActorAlignmentInformations
	{
		public new const short Id = 6780;
		public override short TypeId => Id;
		public ushort honor { get; set; }
		public ushort honorGradeFloor { get; set; }
		public ushort honorNextGradeFloor { get; set; }
		public sbyte aggressable { get; set; }

		public ActorExtendedAlignmentInformations(sbyte alignmentSide, sbyte alignmentValue, sbyte alignmentGrade, double characterPower, ushort honor, ushort honorGradeFloor, ushort honorNextGradeFloor, sbyte aggressable)
		{
			this.alignmentSide = alignmentSide;
			this.alignmentValue = alignmentValue;
			this.alignmentGrade = alignmentGrade;
			this.characterPower = characterPower;
			this.honor = honor;
			this.honorGradeFloor = honorGradeFloor;
			this.honorNextGradeFloor = honorNextGradeFloor;
			this.aggressable = aggressable;
		}

		public ActorExtendedAlignmentInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(honor);
			writer.WriteVarUShort(honorGradeFloor);
			writer.WriteVarUShort(honorNextGradeFloor);
			writer.WriteSByte(aggressable);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			honor = reader.ReadVarUShort();
			honorGradeFloor = reader.ReadVarUShort();
			honorNextGradeFloor = reader.ReadVarUShort();
			aggressable = reader.ReadSByte();
		}

	}
}
