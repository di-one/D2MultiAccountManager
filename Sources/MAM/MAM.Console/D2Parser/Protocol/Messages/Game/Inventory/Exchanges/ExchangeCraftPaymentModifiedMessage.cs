namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeCraftPaymentModifiedMessage : NetworkMessage
	{
		public const uint Id = 1969;
		public override uint MessageId => Id;
		public ulong goldSum { get; set; }

		public ExchangeCraftPaymentModifiedMessage(ulong goldSum)
		{
			this.goldSum = goldSum;
		}

		public ExchangeCraftPaymentModifiedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(goldSum);
		}

		public override void Deserialize(IDataReader reader)
		{
			goldSum = reader.ReadVarULong();
		}

	}
}
