namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStartOkEvolutiveObjectRecycleTradeMessage : NetworkMessage
	{
		public const uint Id = 5224;
		public override uint MessageId => Id;

		public ExchangeStartOkEvolutiveObjectRecycleTradeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
		}

		public override void Deserialize(IDataReader reader)
		{
		}

	}
}
