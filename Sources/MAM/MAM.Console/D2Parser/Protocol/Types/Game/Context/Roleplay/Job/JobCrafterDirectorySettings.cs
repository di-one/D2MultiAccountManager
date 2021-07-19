namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobCrafterDirectorySettings
	{
		public const short Id  = 7816;
		public virtual short TypeId => Id;
		public sbyte jobId { get; set; }
		public byte minLevel { get; set; }
		public bool free { get; set; }

		public JobCrafterDirectorySettings(sbyte jobId, byte minLevel, bool free)
		{
			this.jobId = jobId;
			this.minLevel = minLevel;
			this.free = free;
		}

		public JobCrafterDirectorySettings() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(jobId);
			writer.WriteByte(minLevel);
			writer.WriteBoolean(free);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			jobId = reader.ReadSByte();
			minLevel = reader.ReadByte();
			free = reader.ReadBoolean();
		}

	}
}
