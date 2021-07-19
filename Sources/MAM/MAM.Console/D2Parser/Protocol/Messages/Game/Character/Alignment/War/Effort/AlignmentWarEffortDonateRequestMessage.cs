namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AlignmentWarEffortDonateRequestMessage : NetworkMessage
	{
		public const uint Id = 5050;
		public override uint MessageId => Id;
		public ulong donation { get; set; }

		public AlignmentWarEffortDonateRequestMessage(ulong donation)
		{
			this.donation = donation;
		}

		public AlignmentWarEffortDonateRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(donation);
		}

		public override void Deserialize(IDataReader reader)
		{
			donation = reader.ReadVarULong();
		}

	}
}
