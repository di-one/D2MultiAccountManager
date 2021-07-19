namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AlignmentWarEffortDonatePreviewMessage : NetworkMessage
	{
		public const uint Id = 3836;
		public override uint MessageId => Id;
		public double xp { get; set; }

		public AlignmentWarEffortDonatePreviewMessage(double xp)
		{
			this.xp = xp;
		}

		public AlignmentWarEffortDonatePreviewMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(xp);
		}

		public override void Deserialize(IDataReader reader)
		{
			xp = reader.ReadDouble();
		}

	}
}
