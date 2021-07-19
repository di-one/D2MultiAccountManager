namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeObjectMessage : NetworkMessage
	{
		public const uint Id = 3933;
		public override uint MessageId => Id;
		public bool remote { get; set; }

		public ExchangeObjectMessage(bool remote)
		{
			this.remote = remote;
		}

		public ExchangeObjectMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(remote);
		}

		public override void Deserialize(IDataReader reader)
		{
			remote = reader.ReadBoolean();
		}

	}
}
