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
	public class ExchangeMountsStableAddMessage : NetworkMessage
	{
		public const uint Id = 2432;
		public override uint MessageId => Id;
		public IEnumerable<MountClientData> mountDescription { get; set; }

		public ExchangeMountsStableAddMessage(IEnumerable<MountClientData> mountDescription)
		{
			this.mountDescription = mountDescription;
		}

		public ExchangeMountsStableAddMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)mountDescription.Count());
			foreach (var objectToSend in mountDescription)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var mountDescriptionCount = reader.ReadUShort();
			var mountDescription_ = new MountClientData[mountDescriptionCount];
			for (var mountDescriptionIndex = 0; mountDescriptionIndex < mountDescriptionCount; mountDescriptionIndex++)
			{
				var objectToAdd = new MountClientData();
				objectToAdd.Deserialize(reader);
				mountDescription_[mountDescriptionIndex] = objectToAdd;
			}
			mountDescription = mountDescription_;
		}

	}
}
