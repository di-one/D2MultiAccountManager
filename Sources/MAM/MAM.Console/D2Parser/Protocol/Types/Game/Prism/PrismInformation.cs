namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismInformation
	{
		public const short Id  = 1753;
		public virtual short TypeId => Id;
		public sbyte @typeId { get; set; }
		public sbyte state { get; set; }
		public int nextVulnerabilityDate { get; set; }
		public int placementDate { get; set; }
		public uint rewardTokenCount { get; set; }

		public PrismInformation(sbyte @typeId, sbyte state, int nextVulnerabilityDate, int placementDate, uint rewardTokenCount)
		{
			this.@typeId = @typeId;
			this.state = state;
			this.nextVulnerabilityDate = nextVulnerabilityDate;
			this.placementDate = placementDate;
			this.rewardTokenCount = rewardTokenCount;
		}

		public PrismInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(@typeId);
			writer.WriteSByte(state);
			writer.WriteInt(nextVulnerabilityDate);
			writer.WriteInt(placementDate);
			writer.WriteVarUInt(rewardTokenCount);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			@typeId = reader.ReadSByte();
			state = reader.ReadSByte();
			nextVulnerabilityDate = reader.ReadInt();
			placementDate = reader.ReadInt();
			rewardTokenCount = reader.ReadVarUInt();
		}

	}
}
