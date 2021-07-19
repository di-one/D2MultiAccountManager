namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobCrafterDirectoryDefineSettingsMessage : NetworkMessage
	{
		public const uint Id = 3724;
		public override uint MessageId => Id;
		public JobCrafterDirectorySettings settings { get; set; }

		public JobCrafterDirectoryDefineSettingsMessage(JobCrafterDirectorySettings settings)
		{
			this.settings = settings;
		}

		public JobCrafterDirectoryDefineSettingsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			settings.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			settings = new JobCrafterDirectorySettings();
			settings.Deserialize(reader);
		}

	}
}
