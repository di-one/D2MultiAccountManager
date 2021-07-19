namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobCrafterDirectoryListEntry
	{
		public const short Id  = 8664;
		public virtual short TypeId => Id;
		public JobCrafterDirectoryEntryPlayerInfo playerInfo { get; set; }
		public JobCrafterDirectoryEntryJobInfo jobInfo { get; set; }

		public JobCrafterDirectoryListEntry(JobCrafterDirectoryEntryPlayerInfo playerInfo, JobCrafterDirectoryEntryJobInfo jobInfo)
		{
			this.playerInfo = playerInfo;
			this.jobInfo = jobInfo;
		}

		public JobCrafterDirectoryListEntry() { }

		public virtual void Serialize(IDataWriter writer)
		{
			playerInfo.Serialize(writer);
			jobInfo.Serialize(writer);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			playerInfo = new JobCrafterDirectoryEntryPlayerInfo();
			playerInfo.Deserialize(reader);
			jobInfo = new JobCrafterDirectoryEntryJobInfo();
			jobInfo.Deserialize(reader);
		}

	}
}
