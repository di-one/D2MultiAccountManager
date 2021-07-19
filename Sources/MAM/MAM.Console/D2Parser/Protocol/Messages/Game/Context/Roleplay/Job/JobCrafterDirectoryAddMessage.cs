namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobCrafterDirectoryAddMessage : NetworkMessage
	{
		public const uint Id = 4713;
		public override uint MessageId => Id;
		public JobCrafterDirectoryListEntry listEntry { get; set; }

		public JobCrafterDirectoryAddMessage(JobCrafterDirectoryListEntry listEntry)
		{
			this.listEntry = listEntry;
		}

		public JobCrafterDirectoryAddMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			listEntry.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			listEntry = new JobCrafterDirectoryListEntry();
			listEntry.Deserialize(reader);
		}

	}
}
