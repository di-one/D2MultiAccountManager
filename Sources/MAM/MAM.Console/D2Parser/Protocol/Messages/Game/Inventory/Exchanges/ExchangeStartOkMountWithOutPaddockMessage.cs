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
	public class ExchangeStartOkMountWithOutPaddockMessage : NetworkMessage
	{
		public const uint Id = 4420;
		public override uint MessageId => Id;
		public IEnumerable<MountClientData> stabledMountsDescription { get; set; }

		public ExchangeStartOkMountWithOutPaddockMessage(IEnumerable<MountClientData> stabledMountsDescription)
		{
			this.stabledMountsDescription = stabledMountsDescription;
		}

		public ExchangeStartOkMountWithOutPaddockMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)stabledMountsDescription.Count());
			foreach (var objectToSend in stabledMountsDescription)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var stabledMountsDescriptionCount = reader.ReadUShort();
			var stabledMountsDescription_ = new MountClientData[stabledMountsDescriptionCount];
			for (var stabledMountsDescriptionIndex = 0; stabledMountsDescriptionIndex < stabledMountsDescriptionCount; stabledMountsDescriptionIndex++)
			{
				var objectToAdd = new MountClientData();
				objectToAdd.Deserialize(reader);
				stabledMountsDescription_[stabledMountsDescriptionIndex] = objectToAdd;
			}
			stabledMountsDescription = stabledMountsDescription_;
		}

	}
}
