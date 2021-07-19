namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AlignmentRankUpdateMessage : NetworkMessage
	{
		public const uint Id = 1286;
		public override uint MessageId => Id;
		public sbyte alignmentRank { get; set; }
		public bool verbose { get; set; }

		public AlignmentRankUpdateMessage(sbyte alignmentRank, bool verbose)
		{
			this.alignmentRank = alignmentRank;
			this.verbose = verbose;
		}

		public AlignmentRankUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(alignmentRank);
			writer.WriteBoolean(verbose);
		}

		public override void Deserialize(IDataReader reader)
		{
			alignmentRank = reader.ReadSByte();
			verbose = reader.ReadBoolean();
		}

	}
}
