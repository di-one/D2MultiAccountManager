namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceFactsRequestMessage : NetworkMessage
	{
		public const uint Id = 5404;
		public override uint MessageId => Id;
		public uint allianceId { get; set; }

		public AllianceFactsRequestMessage(uint allianceId)
		{
			this.allianceId = allianceId;
		}

		public AllianceFactsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(allianceId);
		}

		public override void Deserialize(IDataReader reader)
		{
			allianceId = reader.ReadVarUInt();
		}

	}
}
