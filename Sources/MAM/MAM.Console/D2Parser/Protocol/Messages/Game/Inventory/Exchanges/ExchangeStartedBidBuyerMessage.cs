namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStartedBidBuyerMessage : NetworkMessage
	{
		public const uint Id = 4958;
		public override uint MessageId => Id;
		public SellerBuyerDescriptor buyerDescriptor { get; set; }

		public ExchangeStartedBidBuyerMessage(SellerBuyerDescriptor buyerDescriptor)
		{
			this.buyerDescriptor = buyerDescriptor;
		}

		public ExchangeStartedBidBuyerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			buyerDescriptor.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			buyerDescriptor = new SellerBuyerDescriptor();
			buyerDescriptor.Deserialize(reader);
		}

	}
}
