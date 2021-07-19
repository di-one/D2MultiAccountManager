namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceInvitedMessage : NetworkMessage
	{
		public const uint Id = 6014;
		public override uint MessageId => Id;
		public ulong recruterId { get; set; }
		public string recruterName { get; set; }
		public BasicNamedAllianceInformations allianceInfo { get; set; }

		public AllianceInvitedMessage(ulong recruterId, string recruterName, BasicNamedAllianceInformations allianceInfo)
		{
			this.recruterId = recruterId;
			this.recruterName = recruterName;
			this.allianceInfo = allianceInfo;
		}

		public AllianceInvitedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(recruterId);
			writer.WriteUTF(recruterName);
			allianceInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			recruterId = reader.ReadVarULong();
			recruterName = reader.ReadUTF();
			allianceInfo = new BasicNamedAllianceInformations();
			allianceInfo.Deserialize(reader);
		}

	}
}
