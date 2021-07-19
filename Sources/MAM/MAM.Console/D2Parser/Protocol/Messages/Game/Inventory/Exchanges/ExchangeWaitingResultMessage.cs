namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeWaitingResultMessage : NetworkMessage
	{
		public const uint Id = 5604;
		public override uint MessageId => Id;
		public bool bwait { get; set; }

		public ExchangeWaitingResultMessage(bool bwait)
		{
			this.bwait = bwait;
		}

		public ExchangeWaitingResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(bwait);
		}

		public override void Deserialize(IDataReader reader)
		{
			bwait = reader.ReadBoolean();
		}

	}
}
