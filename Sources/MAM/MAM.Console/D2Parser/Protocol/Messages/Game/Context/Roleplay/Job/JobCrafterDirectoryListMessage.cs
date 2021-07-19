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
	public class JobCrafterDirectoryListMessage : NetworkMessage
	{
		public const uint Id = 996;
		public override uint MessageId => Id;
		public IEnumerable<JobCrafterDirectoryListEntry> listEntries { get; set; }

		public JobCrafterDirectoryListMessage(IEnumerable<JobCrafterDirectoryListEntry> listEntries)
		{
			this.listEntries = listEntries;
		}

		public JobCrafterDirectoryListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)listEntries.Count());
			foreach (var objectToSend in listEntries)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var listEntriesCount = reader.ReadUShort();
			var listEntries_ = new JobCrafterDirectoryListEntry[listEntriesCount];
			for (var listEntriesIndex = 0; listEntriesIndex < listEntriesCount; listEntriesIndex++)
			{
				var objectToAdd = new JobCrafterDirectoryListEntry();
				objectToAdd.Deserialize(reader);
				listEntries_[listEntriesIndex] = objectToAdd;
			}
			listEntries = listEntries_;
		}

	}
}
