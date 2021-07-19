namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdentificationAccountForceMessage : IdentificationMessage
	{
		public new const uint Id = 3004;
		public override uint MessageId => Id;
		public string forcedAccountLogin { get; set; }

		public IdentificationAccountForceMessage(bool autoconnect, bool useCertificate, bool useLoginToken, Types.Version version, string lang, IEnumerable<sbyte> credentials, short serverId, long sessionOptionalSalt, IEnumerable<ushort> failedAttempts, string forcedAccountLogin)
		{
			this.autoconnect = autoconnect;
			this.useCertificate = useCertificate;
			this.useLoginToken = useLoginToken;
			this.version = version;
			this.lang = lang;
			this.credentials = credentials;
			this.serverId = serverId;
			this.sessionOptionalSalt = sessionOptionalSalt;
			this.failedAttempts = failedAttempts;
			this.forcedAccountLogin = forcedAccountLogin;
		}

		public IdentificationAccountForceMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(forcedAccountLogin);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			forcedAccountLogin = reader.ReadUTF();
		}

	}
}
