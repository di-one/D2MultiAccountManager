namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockBuyResultMessage : NetworkMessage
	{
		public const uint Id = 1222;
		public override uint MessageId => Id;
		public double paddockId { get; set; }
		public bool bought { get; set; }
		public ulong realPrice { get; set; }

		public PaddockBuyResultMessage(double paddockId, bool bought, ulong realPrice)
		{
			this.paddockId = paddockId;
			this.bought = bought;
			this.realPrice = realPrice;
		}

		public PaddockBuyResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(paddockId);
			writer.WriteBoolean(bought);
			writer.WriteVarULong(realPrice);
		}

		public override void Deserialize(IDataReader reader)
		{
			paddockId = reader.ReadDouble();
			bought = reader.ReadBoolean();
			realPrice = reader.ReadVarULong();
		}

	}
}
