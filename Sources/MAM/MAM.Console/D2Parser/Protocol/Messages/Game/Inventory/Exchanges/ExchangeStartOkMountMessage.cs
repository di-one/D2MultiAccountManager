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
	public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
	{
		public new const uint Id = 5852;
		public override uint MessageId => Id;
		public IEnumerable<MountClientData> paddockedMountsDescription { get; set; }

		public ExchangeStartOkMountMessage(IEnumerable<MountClientData> stabledMountsDescription, IEnumerable<MountClientData> paddockedMountsDescription)
		{
			this.stabledMountsDescription = stabledMountsDescription;
			this.paddockedMountsDescription = paddockedMountsDescription;
		}

		public ExchangeStartOkMountMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)paddockedMountsDescription.Count());
			foreach (var objectToSend in paddockedMountsDescription)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var paddockedMountsDescriptionCount = reader.ReadUShort();
			var paddockedMountsDescription_ = new MountClientData[paddockedMountsDescriptionCount];
			for (var paddockedMountsDescriptionIndex = 0; paddockedMountsDescriptionIndex < paddockedMountsDescriptionCount; paddockedMountsDescriptionIndex++)
			{
				var objectToAdd = new MountClientData();
				objectToAdd.Deserialize(reader);
				paddockedMountsDescription_[paddockedMountsDescriptionIndex] = objectToAdd;
			}
			paddockedMountsDescription = paddockedMountsDescription_;
		}

	}
}
