namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceFactsErrorMessage : NetworkMessage
	{
		public const uint Id = 1681;
		public override uint MessageId => Id;
		public uint allianceId { get; set; }

		public AllianceFactsErrorMessage(uint allianceId)
		{
			this.allianceId = allianceId;
		}

		public AllianceFactsErrorMessage() { }

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
