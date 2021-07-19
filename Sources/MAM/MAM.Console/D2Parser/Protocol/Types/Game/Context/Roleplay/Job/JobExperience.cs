namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobExperience
	{
		public const short Id  = 754;
		public virtual short TypeId => Id;
		public sbyte jobId { get; set; }
		public byte jobLevel { get; set; }
		public ulong jobXP { get; set; }
		public ulong jobXpLevelFloor { get; set; }
		public ulong jobXpNextLevelFloor { get; set; }

		public JobExperience(sbyte jobId, byte jobLevel, ulong jobXP, ulong jobXpLevelFloor, ulong jobXpNextLevelFloor)
		{
			this.jobId = jobId;
			this.jobLevel = jobLevel;
			this.jobXP = jobXP;
			this.jobXpLevelFloor = jobXpLevelFloor;
			this.jobXpNextLevelFloor = jobXpNextLevelFloor;
		}

		public JobExperience() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(jobId);
			writer.WriteByte(jobLevel);
			writer.WriteVarULong(jobXP);
			writer.WriteVarULong(jobXpLevelFloor);
			writer.WriteVarULong(jobXpNextLevelFloor);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			jobId = reader.ReadSByte();
			jobLevel = reader.ReadByte();
			jobXP = reader.ReadVarULong();
			jobXpLevelFloor = reader.ReadVarULong();
			jobXpNextLevelFloor = reader.ReadVarULong();
		}

	}
}
