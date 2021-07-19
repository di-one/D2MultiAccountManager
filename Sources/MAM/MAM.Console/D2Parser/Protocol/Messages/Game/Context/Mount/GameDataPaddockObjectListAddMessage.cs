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
	public class GameDataPaddockObjectListAddMessage : NetworkMessage
	{
		public const uint Id = 496;
		public override uint MessageId => Id;
		public IEnumerable<PaddockItem> paddockItemDescription { get; set; }

		public GameDataPaddockObjectListAddMessage(IEnumerable<PaddockItem> paddockItemDescription)
		{
			this.paddockItemDescription = paddockItemDescription;
		}

		public GameDataPaddockObjectListAddMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)paddockItemDescription.Count());
			foreach (var objectToSend in paddockItemDescription)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var paddockItemDescriptionCount = reader.ReadUShort();
			var paddockItemDescription_ = new PaddockItem[paddockItemDescriptionCount];
			for (var paddockItemDescriptionIndex = 0; paddockItemDescriptionIndex < paddockItemDescriptionCount; paddockItemDescriptionIndex++)
			{
				var objectToAdd = new PaddockItem();
				objectToAdd.Deserialize(reader);
				paddockItemDescription_[paddockItemDescriptionIndex] = objectToAdd;
			}
			paddockItemDescription = paddockItemDescription_;
		}

	}
}
