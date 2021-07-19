namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobCrafterDirectoryEntryMessage : NetworkMessage
	{
		public const uint Id = 9241;
		public override uint MessageId => Id;
		public JobCrafterDirectoryEntryPlayerInfo playerInfo { get; set; }
		public IEnumerable<JobCrafterDirectoryEntryJobInfo> jobInfoList { get; set; }
		public EntityLook playerLook { get; set; }

		public JobCrafterDirectoryEntryMessage(JobCrafterDirectoryEntryPlayerInfo playerInfo, IEnumerable<JobCrafterDirectoryEntryJobInfo> jobInfoList, EntityLook playerLook)
		{
			this.playerInfo = playerInfo;
			this.jobInfoList = jobInfoList;
			this.playerLook = playerLook;
		}

		public JobCrafterDirectoryEntryMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			playerInfo.Serialize(writer);
			writer.WriteShort((short)jobInfoList.Count());
			foreach (var objectToSend in jobInfoList)
            {
				objectToSend.Serialize(writer);
			}
			playerLook.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			playerInfo = new JobCrafterDirectoryEntryPlayerInfo();
			playerInfo.Deserialize(reader);
			var jobInfoListCount = reader.ReadUShort();
			var jobInfoList_ = new JobCrafterDirectoryEntryJobInfo[jobInfoListCount];
			for (var jobInfoListIndex = 0; jobInfoListIndex < jobInfoListCount; jobInfoListIndex++)
			{
				var objectToAdd = new JobCrafterDirectoryEntryJobInfo();
				objectToAdd.Deserialize(reader);
				jobInfoList_[jobInfoListIndex] = objectToAdd;
			}
			jobInfoList = jobInfoList_;
			playerLook = new EntityLook();
			playerLook.Deserialize(reader);
		}

	}
}
