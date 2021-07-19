namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ItemForPresetUpdateMessage : NetworkMessage
	{
		public const uint Id = 12;
		public override uint MessageId => Id;
		public short presetId { get; set; }
		public ItemForPreset presetItem { get; set; }

		public ItemForPresetUpdateMessage(short presetId, ItemForPreset presetItem)
		{
			this.presetId = presetId;
			this.presetItem = presetItem;
		}

		public ItemForPresetUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(presetId);
			presetItem.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			presetId = reader.ReadShort();
			presetItem = new ItemForPreset();
			presetItem.Deserialize(reader);
		}

	}
}
