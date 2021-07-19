namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseSellRequestMessage : NetworkMessage
	{
		public const uint Id = 1652;
		public override uint MessageId => Id;
		public int instanceId { get; set; }
		public ulong amount { get; set; }
		public bool forSale { get; set; }

		public HouseSellRequestMessage(int instanceId, ulong amount, bool forSale)
		{
			this.instanceId = instanceId;
			this.amount = amount;
			this.forSale = forSale;
		}

		public HouseSellRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(instanceId);
			writer.WriteVarULong(amount);
			writer.WriteBoolean(forSale);
		}

		public override void Deserialize(IDataReader reader)
		{
			instanceId = reader.ReadInt();
			amount = reader.ReadVarULong();
			forSale = reader.ReadBoolean();
		}

	}
}
