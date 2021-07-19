namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
	{
		public new const uint Id = 3029;
		public override uint MessageId => Id;
		public string loginToken { get; set; }

		public IdentificationSuccessWithLoginTokenMessage(bool hasRights, bool hasConsoleRight, bool wasAlreadyConnected, string login, AccountTagInformation accountTag, int accountId, sbyte communityId, string secretQuestion, double accountCreation, double subscriptionElapsedDuration, double subscriptionEndDate, byte havenbagAvailableRoom, string loginToken)
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
			this.loginToken = loginToken;
		}

		public IdentificationSuccessWithLoginTokenMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(loginToken);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			loginToken = reader.ReadUTF();
		}

	}
}
