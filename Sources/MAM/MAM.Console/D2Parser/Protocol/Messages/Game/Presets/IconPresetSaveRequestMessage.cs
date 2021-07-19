namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IconPresetSaveRequestMessage : NetworkMessage
	{
		public const uint Id = 4174;
		public override uint MessageId => Id;
		public short presetId { get; set; }
		public sbyte symbolId { get; set; }
		public bool updateData { get; set; }

		public IconPresetSaveRequestMessage(short presetId, sbyte symbolId, bool updateData)
		{
			this.presetId = presetId;
			this.symbolId = symbolId;
			this.updateData = updateData;
		}

		public IconPresetSaveRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(presetId);
			writer.WriteSByte(symbolId);
			writer.WriteBoolean(updateData);
		}

		public override void Deserialize(IDataReader reader)
		{
			presetId = reader.ReadShort();
			symbolId = reader.ReadSByte();
			updateData = reader.ReadBoolean();
		}

	}
}
