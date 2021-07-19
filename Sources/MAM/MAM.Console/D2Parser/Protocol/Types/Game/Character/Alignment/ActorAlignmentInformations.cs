namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ActorAlignmentInformations
	{
		public const short Id  = 927;
		public virtual short TypeId => Id;
		public sbyte alignmentSide { get; set; }
		public sbyte alignmentValue { get; set; }
		public sbyte alignmentGrade { get; set; }
		public double characterPower { get; set; }

		public ActorAlignmentInformations(sbyte alignmentSide, sbyte alignmentValue, sbyte alignmentGrade, double characterPower)
		{
			this.alignmentSide = alignmentSide;
			this.alignmentValue = alignmentValue;
			this.alignmentGrade = alignmentGrade;
			this.characterPower = characterPower;
		}

		public ActorAlignmentInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(alignmentSide);
			writer.WriteSByte(alignmentValue);
			writer.WriteSByte(alignmentGrade);
			writer.WriteDouble(characterPower);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			alignmentSide = reader.ReadSByte();
			alignmentValue = reader.ReadSByte();
			alignmentGrade = reader.ReadSByte();
			characterPower = reader.ReadDouble();
		}

	}
}
