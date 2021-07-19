namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AccountInformationsUpdateMessage : NetworkMessage
	{
		public const uint Id = 1933;
		public override uint MessageId => Id;
		public double subscriptionEndDate { get; set; }

		public AccountInformationsUpdateMessage(double subscriptionEndDate)
		{
			this.subscriptionEndDate = subscriptionEndDate;
		}

		public AccountInformationsUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(subscriptionEndDate);
		}

		public override void Deserialize(IDataReader reader)
		{
			subscriptionEndDate = reader.ReadDouble();
		}

	}
}
