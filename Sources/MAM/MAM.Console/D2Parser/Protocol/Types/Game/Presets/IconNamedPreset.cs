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
	public class IconNamedPreset : PresetsContainerPreset
	{
		public new const short Id = 7031;
		public override short TypeId => Id;
		public short iconId { get; set; }
		public string name { get; set; }

		public IconNamedPreset(short objectId, IEnumerable<Preset> presets, short iconId, string name)
		{
			this.objectId = objectId;
			this.presets = presets;
			this.iconId = iconId;
			this.name = name;
		}

		public IconNamedPreset() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(iconId);
			writer.WriteUTF(name);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			iconId = reader.ReadShort();
			name = reader.ReadUTF();
		}

	}
}
