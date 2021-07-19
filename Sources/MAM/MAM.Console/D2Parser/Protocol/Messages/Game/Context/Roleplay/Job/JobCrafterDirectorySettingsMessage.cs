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
	public class JobCrafterDirectorySettingsMessage : NetworkMessage
	{
		public const uint Id = 8059;
		public override uint MessageId => Id;
		public IEnumerable<JobCrafterDirectorySettings> craftersSettings { get; set; }

		public JobCrafterDirectorySettingsMessage(IEnumerable<JobCrafterDirectorySettings> craftersSettings)
		{
			this.craftersSettings = craftersSettings;
		}

		public JobCrafterDirectorySettingsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)craftersSettings.Count());
			foreach (var objectToSend in craftersSettings)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var craftersSettingsCount = reader.ReadUShort();
			var craftersSettings_ = new JobCrafterDirectorySettings[craftersSettingsCount];
			for (var craftersSettingsIndex = 0; craftersSettingsIndex < craftersSettingsCount; craftersSettingsIndex++)
			{
				var objectToAdd = new JobCrafterDirectorySettings();
				objectToAdd.Deserialize(reader);
				craftersSettings_[craftersSettingsIndex] = objectToAdd;
			}
			craftersSettings = craftersSettings_;
		}

	}
}
