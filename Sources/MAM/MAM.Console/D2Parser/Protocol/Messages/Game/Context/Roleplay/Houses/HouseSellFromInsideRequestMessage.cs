namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseSellFromInsideRequestMessage : HouseSellRequestMessage
	{
		public new const uint Id = 4554;
		public override uint MessageId => Id;

		public HouseSellFromInsideRequestMessage(int instanceId, ulong amount, bool forSale)
		{
			this.instanceId = instanceId;
			this.amount = amount;
			this.forSale = forSale;
		}

		public HouseSellFromInsideRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
