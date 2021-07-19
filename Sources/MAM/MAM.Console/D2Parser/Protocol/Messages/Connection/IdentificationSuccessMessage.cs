namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdentificationSuccessMessage : NetworkMessage
	{
		public const uint Id = 7272;
		public override uint MessageId => Id;
		public bool hasRights { get; set; }
		public bool hasConsoleRight { get; set; }
		public bool wasAlreadyConnected { get; set; }
		public string login { get; set; }
		public AccountTagInformation accountTag { get; set; }
		public int accountId { get; set; }
		public sbyte communityId { get; set; }
		public string secretQuestion { get; set; }
		public double accountCreation { get; set; }
		public double subscriptionElapsedDuration { get; set; }
		public double subscriptionEndDate { get; set; }
		public byte havenbagAvailableRoom { get; set; }

		public IdentificationSuccessMessage(bool hasRights, bool hasConsoleRight, bool wasAlreadyConnected, string login, AccountTagInformation accountTag, int accountId, sbyte communityId, string secretQuestion, double accountCreation, double subscriptionElapsedDuration, double subscriptionEndDate, byte havenbagAvailableRoom)
		{
			this.hasRights = hasRights;
			this.hasConsoleRight = hasConsoleRight;
			this.wasAlreadyConnected = wasAlreadyConnected;
			this.login = login;
			this.accountTag = accountTag;
			this.accountId = accountId;
			this.communityId = communityId;
			this.secretQuestion = secretQuestion;
			this.accountCreation = accountCreation;
			this.subscriptionElapsedDuration = subscriptionElapsedDuration;
			this.subscriptionEndDate = subscriptionEndDate;
			this.havenbagAvailableRoom = havenbagAvailableRoom;
		}

		public IdentificationSuccessMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, hasRights);
			flag = BooleanByteWrapper.SetFlag(flag, 1, hasConsoleRight);
			flag = BooleanByteWrapper.SetFlag(flag, 2, wasAlreadyConnected);
			writer.WriteByte(flag);
			writer.WriteUTF(login);
			accountTag.Serialize(writer);
			writer.WriteInt(accountId);
			writer.WriteSByte(communityId);
			writer.WriteUTF(secretQuestion);
			writer.WriteDouble(accountCreation);
			writer.WriteDouble(subscriptionElapsedDuration);
			writer.WriteDouble(subscriptionEndDate);
			writer.WriteByte(havenbagAvailableRoom);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			hasRights = BooleanByteWrapper.GetFlag(flag, 0);
			hasConsoleRight = BooleanByteWrapper.GetFlag(flag, 1);
			wasAlreadyConnected = BooleanByteWrapper.GetFlag(flag, 2);
			login = reader.ReadUTF();
			accountTag = new AccountTagInformation();
			accountTag.Deserialize(reader);
			accountId = reader.ReadInt();
			communityId = reader.ReadSByte();
			secretQuestion = reader.ReadUTF();
			accountCreation = reader.ReadDouble();
			subscriptionElapsedDuration = reader.ReadDouble();
			subscriptionEndDate = reader.ReadDouble();
			havenbagAvailableRoom = reader.ReadByte();
		}

	}
}
