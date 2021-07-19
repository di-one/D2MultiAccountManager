namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AnomalySubareaInformation
	{
		public const short Id  = 1547;
		public virtual short TypeId => Id;
		public ushort subAreaId { get; set; }
		public short rewardRate { get; set; }
		public bool hasAnomaly { get; set; }
		public ulong anomalyClosingTime { get; set; }

		public AnomalySubareaInformation(ushort subAreaId, short rewardRate, bool hasAnomaly, ulong anomalyClosingTime)
		{
			this.subAreaId = subAreaId;
			this.rewardRate = rewardRate;
			this.hasAnomaly = hasAnomaly;
			this.anomalyClosingTime = anomalyClosingTime;
		}

		public AnomalySubareaInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteVarShort(rewardRate);
			writer.WriteBoolean(hasAnomaly);
			writer.WriteVarULong(anomalyClosingTime);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			rewardRate = reader.ReadVarShort();
			hasAnomaly = reader.ReadBoolean();
			anomalyClosingTime = reader.ReadVarULong();
		}

	}
}
