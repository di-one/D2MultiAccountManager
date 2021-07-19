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
	public class PresetsMessage : NetworkMessage
	{
		public const uint Id = 600;
		public override uint MessageId => Id;
		public IEnumerable<Preset> presets { get; set; }

		public PresetsMessage(IEnumerable<Preset> presets)
		{
			this.presets = presets;
		}

		public PresetsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)presets.Count());
			foreach (var objectToSend in presets)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var presetsCount = reader.ReadUShort();
			var presets_ = new Preset[presetsCount];
			for (var presetsIndex = 0; presetsIndex < presetsCount; presetsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<Preset>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				presets_[presetsIndex] = objectToAdd;
			}
			presets = presets_;
		}

	}
}
