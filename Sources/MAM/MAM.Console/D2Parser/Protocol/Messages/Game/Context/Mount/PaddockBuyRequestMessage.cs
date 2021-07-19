namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockBuyRequestMessage : NetworkMessage
	{
		public const uint Id = 1527;
		public override uint MessageId => Id;
		public ulong proposedPrice { get; set; }

		public PaddockBuyRequestMessage(ulong proposedPrice)
		{
			this.proposedPrice = proposedPrice;
		}

		public PaddockBuyRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(proposedPrice);
		}

		public override void Deserialize(IDataReader reader)
		{
			proposedPrice = reader.ReadVarULong();
		}

	}
}
