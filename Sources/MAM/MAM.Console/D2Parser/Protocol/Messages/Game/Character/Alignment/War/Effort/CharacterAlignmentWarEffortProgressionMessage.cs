namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterAlignmentWarEffortProgressionMessage : NetworkMessage
	{
		public const uint Id = 6450;
		public override uint MessageId => Id;
		public ulong alignmentWarEffortDailyLimit { get; set; }
		public ulong alignmentWarEffortDailyDonation { get; set; }
		public ulong alignmentWarEffortPersonalDonation { get; set; }

		public CharacterAlignmentWarEffortProgressionMessage(ulong alignmentWarEffortDailyLimit, ulong alignmentWarEffortDailyDonation, ulong alignmentWarEffortPersonalDonation)
		{
			this.alignmentWarEffortDailyLimit = alignmentWarEffortDailyLimit;
			this.alignmentWarEffortDailyDonation = alignmentWarEffortDailyDonation;
			this.alignmentWarEffortPersonalDonation = alignmentWarEffortPersonalDonation;
		}

		public CharacterAlignmentWarEffortProgressionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(alignmentWarEffortDailyLimit);
			writer.WriteVarULong(alignmentWarEffortDailyDonation);
			writer.WriteVarULong(alignmentWarEffortPersonalDonation);
		}

		public override void Deserialize(IDataReader reader)
		{
			alignmentWarEffortDailyLimit = reader.ReadVarULong();
			alignmentWarEffortDailyDonation = reader.ReadVarULong();
			alignmentWarEffortPersonalDonation = reader.ReadVarULong();
		}

	}
}
