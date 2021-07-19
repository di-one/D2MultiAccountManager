namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AlignmentWarEffortDonationResultMessage : NetworkMessage
	{
		public const uint Id = 6266;
		public override uint MessageId => Id;
		public sbyte result { get; set; }

		public AlignmentWarEffortDonationResultMessage(sbyte result)
		{
			this.result = result;
		}

		public AlignmentWarEffortDonationResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(result);
		}

		public override void Deserialize(IDataReader reader)
		{
			result = reader.ReadSByte();
		}

	}
}
