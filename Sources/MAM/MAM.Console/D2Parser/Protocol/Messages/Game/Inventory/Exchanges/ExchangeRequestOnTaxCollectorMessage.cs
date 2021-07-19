namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeRequestOnTaxCollectorMessage : NetworkMessage
	{
		public const uint Id = 464;
		public override uint MessageId => Id;

		public ExchangeRequestOnTaxCollectorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
		}

		public override void Deserialize(IDataReader reader)
		{
		}

	}
}
