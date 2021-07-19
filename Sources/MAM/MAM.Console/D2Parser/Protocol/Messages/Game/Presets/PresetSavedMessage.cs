namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PresetSavedMessage : NetworkMessage
	{
		public const uint Id = 3811;
		public override uint MessageId => Id;
		public short presetId { get; set; }
		public Preset preset { get; set; }

		public PresetSavedMessage(short presetId, Preset preset)
		{
			this.presetId = presetId;
			this.preset = preset;
		}

		public PresetSavedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(presetId);
			writer.WriteShort(preset.TypeId);
			preset.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			presetId = reader.ReadShort();
			preset = ProtocolTypeManager.GetInstance<Preset>(reader.ReadShort());
			preset.Deserialize(reader);
		}

	}
}
