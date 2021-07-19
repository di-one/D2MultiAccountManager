namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceJoinedMessage : NetworkMessage
	{
		public const uint Id = 9123;
		public override uint MessageId => Id;
		public AllianceInformations allianceInfo { get; set; }
		public bool enabled { get; set; }
		public uint leadingGuildId { get; set; }

		public AllianceJoinedMessage(AllianceInformations allianceInfo, bool enabled, uint leadingGuildId)
		{
			this.allianceInfo = allianceInfo;
			this.enabled = enabled;
			this.leadingGuildId = leadingGuildId;
		}

		public AllianceJoinedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			allianceInfo.Serialize(writer);
			writer.WriteBoolean(enabled);
			writer.WriteVarUInt(leadingGuildId);
		}

		public override void Deserialize(IDataReader reader)
		{
			allianceInfo = new AllianceInformations();
			allianceInfo.Deserialize(reader);
			enabled = reader.ReadBoolean();
			leadingGuildId = reader.ReadVarUInt();
		}

	}
}
