namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeMoneyMovementInformationMessage : NetworkMessage
	{
		public const uint Id = 2517;
		public override uint MessageId => Id;
		public ulong limit { get; set; }

		public ExchangeMoneyMovementInformationMessage(ulong limit)
		{
			this.limit = limit;
		}

		public ExchangeMoneyMovementInformationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(limit);
		}

		public override void Deserialize(IDataReader reader)
		{
			limit = reader.ReadVarULong();
		}

	}
}
