namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IconNamedPresetSaveRequestMessage : IconPresetSaveRequestMessage
	{
		public new const uint Id = 6473;
		public override uint MessageId => Id;
		public string name { get; set; }
		public sbyte type { get; set; }

		public IconNamedPresetSaveRequestMessage(short presetId, sbyte symbolId, bool updateData, string name, sbyte type)
		{
			this.presetId = presetId;
			this.symbolId = symbolId;
			this.updateData = updateData;
			this.name = name;
			this.type = type;
		}

		public IconNamedPresetSaveRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
			writer.WriteSByte(type);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
			type = reader.ReadSByte();
		}

	}
}
