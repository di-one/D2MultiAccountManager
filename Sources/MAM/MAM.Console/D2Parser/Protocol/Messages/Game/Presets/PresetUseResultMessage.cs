namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PresetUseResultMessage : NetworkMessage
	{
		public const uint Id = 9459;
		public override uint MessageId => Id;
		public short presetId { get; set; }
		public sbyte code { get; set; }

		public PresetUseResultMessage(short presetId, sbyte code)
		{
			this.presetId = presetId;
			this.code = code;
		}

		public PresetUseResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(presetId);
			writer.WriteSByte(code);
		}

		public override void Deserialize(IDataReader reader)
		{
			presetId = reader.ReadShort();
			code = reader.ReadSByte();
		}

	}
}
