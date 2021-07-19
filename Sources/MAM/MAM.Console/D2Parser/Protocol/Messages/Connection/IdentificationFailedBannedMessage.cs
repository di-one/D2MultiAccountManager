namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdentificationFailedBannedMessage : IdentificationFailedMessage
	{
		public new const uint Id = 9046;
		public override uint MessageId => Id;
		public double banEndDate { get; set; }

		public IdentificationFailedBannedMessage(sbyte reason, double banEndDate)
		{
			this.reason = reason;
			this.banEndDate = banEndDate;
		}

		public IdentificationFailedBannedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(banEndDate);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			banEndDate = reader.ReadDouble();
		}

	}
}
