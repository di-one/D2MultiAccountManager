namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PresetsContainerPreset : Preset
	{
		public new const short Id = 4064;
		public override short TypeId => Id;
		public IEnumerable<Preset> presets { get; set; }

		public PresetsContainerPreset(short objectId, IEnumerable<Preset> presets)
		{
			this.objectId = objectId;
			this.presets = presets;
		}

		public PresetsContainerPreset() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)presets.Count());
			foreach (var objectToSend in presets)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
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
