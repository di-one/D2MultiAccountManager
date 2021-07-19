namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AlignmentWarEffortInformation
	{
		public const short Id  = 9099;
		public virtual short TypeId => Id;
		public sbyte alignmentSide { get; set; }
		public ulong alignmentWarEffort { get; set; }

		public AlignmentWarEffortInformation(sbyte alignmentSide, ulong alignmentWarEffort)
		{
			this.alignmentSide = alignmentSide;
			this.alignmentWarEffort = alignmentWarEffort;
		}

		public AlignmentWarEffortInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(alignmentSide);
			writer.WriteVarULong(alignmentWarEffort);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			alignmentSide = reader.ReadSByte();
			alignmentWarEffort = reader.ReadVarULong();
		}

	}
}
