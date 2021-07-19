namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PresetUseRequestMessage : NetworkMessage
	{
		public const uint Id = 4410;
		public override uint MessageId => Id;
		public short presetId { get; set; }

		public PresetUseRequestMessage(short presetId)
		{
			this.presetId = presetId;
		}

		public PresetUseRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(presetId);
		}

		public override void Deserialize(IDataReader reader)
		{
			presetId = reader.ReadShort();
		}

	}
}
