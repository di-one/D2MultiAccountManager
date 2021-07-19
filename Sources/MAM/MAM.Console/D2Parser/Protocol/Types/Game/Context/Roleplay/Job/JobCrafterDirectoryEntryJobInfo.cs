namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobCrafterDirectoryEntryJobInfo
	{
		public const short Id  = 7352;
		public virtual short TypeId => Id;
		public sbyte jobId { get; set; }
		public byte jobLevel { get; set; }
		public bool free { get; set; }
		public byte minLevel { get; set; }

		public JobCrafterDirectoryEntryJobInfo(sbyte jobId, byte jobLevel, bool free, byte minLevel)
		{
			this.jobId = jobId;
			this.jobLevel = jobLevel;
			this.free = free;
			this.minLevel = minLevel;
		}

		public JobCrafterDirectoryEntryJobInfo() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(jobId);
			writer.WriteByte(jobLevel);
			writer.WriteBoolean(free);
			writer.WriteByte(minLevel);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			jobId = reader.ReadSByte();
			jobLevel = reader.ReadByte();
			free = reader.ReadBoolean();
			minLevel = reader.ReadByte();
		}

	}
}
