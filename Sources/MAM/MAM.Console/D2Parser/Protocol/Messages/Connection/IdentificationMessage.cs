namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;
	using Version = AmaknaProxy.API.Protocol.Types.Version;

	[Serializable]
	public class IdentificationMessage : NetworkMessage
	{
		public const uint Id = 2767;
		public override uint MessageId => Id;
		public bool autoconnect { get; set; }
		public bool useCertificate { get; set; }
		public bool useLoginToken { get; set; }
		public Version version { get; set; }
		public string lang { get; set; }
		public IEnumerable<sbyte> credentials { get; set; }
		public short serverId { get; set; }
		public long sessionOptionalSalt { get; set; }
		public IEnumerable<ushort> failedAttempts { get; set; }

		public IdentificationMessage(bool autoconnect, bool useCertificate, bool useLoginToken, Version version, string lang, IEnumerable<sbyte> credentials, short serverId, long sessionOptionalSalt, IEnumerable<ushort> failedAttempts)
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
		}

		public IdentificationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, autoconnect);
			flag = BooleanByteWrapper.SetFlag(flag, 1, useCertificate);
			flag = BooleanByteWrapper.SetFlag(flag, 2, useLoginToken);
			writer.WriteByte(flag);
			version.Serialize(writer);
			writer.WriteUTF(lang);
			writer.WriteVarInt(credentials.Count());
			foreach (var objectToSend in credentials)
            {
				writer.WriteSByte(objectToSend);
			}
			writer.WriteShort(serverId);
			writer.WriteVarLong(sessionOptionalSalt);
			writer.WriteShort((short)failedAttempts.Count());
			foreach (var objectToSend in failedAttempts)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			autoconnect = BooleanByteWrapper.GetFlag(flag, 0);
			useCertificate = BooleanByteWrapper.GetFlag(flag, 1);
			useLoginToken = BooleanByteWrapper.GetFlag(flag, 2);
			version = new Version();
			version.Deserialize(reader);
			lang = reader.ReadUTF();
			var credentialsCount = reader.ReadVarInt();
			var credentials_ = new sbyte[credentialsCount];
			for (var credentialsIndex = 0; credentialsIndex < credentialsCount; credentialsIndex++)
			{
				credentials_[credentialsIndex] = reader.ReadSByte();
			}
			credentials = credentials_;
			serverId = reader.ReadShort();
			sessionOptionalSalt = reader.ReadVarLong();
			var failedAttemptsCount = reader.ReadUShort();
			var failedAttempts_ = new ushort[failedAttemptsCount];
			for (var failedAttemptsIndex = 0; failedAttemptsIndex < failedAttemptsCount; failedAttemptsIndex++)
			{
				failedAttempts_[failedAttemptsIndex] = reader.ReadVarUShort();
			}
			failedAttempts = failedAttempts_;
		}

	}
}
