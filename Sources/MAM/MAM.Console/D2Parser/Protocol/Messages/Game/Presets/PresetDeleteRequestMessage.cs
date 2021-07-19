namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PresetDeleteRequestMessage : NetworkMessage
	{
		public const uint Id = 8091;
		public override uint MessageId => Id;
		public short presetId { get; set; }

		public PresetDeleteRequestMessage(short presetId)
		{
			this.presetId = presetId;
		}

		public PresetDeleteRequestMessage() { }

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
