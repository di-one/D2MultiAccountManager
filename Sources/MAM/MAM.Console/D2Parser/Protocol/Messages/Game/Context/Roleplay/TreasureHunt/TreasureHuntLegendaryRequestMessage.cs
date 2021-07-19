namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntLegendaryRequestMessage : NetworkMessage
	{
		public const uint Id = 7019;
		public override uint MessageId => Id;
		public ushort legendaryId { get; set; }

		public TreasureHuntLegendaryRequestMessage(ushort legendaryId)
		{
			this.legendaryId = legendaryId;
		}

		public TreasureHuntLegendaryRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(legendaryId);
		}

		public override void Deserialize(IDataReader reader)
		{
			legendaryId = reader.ReadVarUShort();
		}

	}
}
