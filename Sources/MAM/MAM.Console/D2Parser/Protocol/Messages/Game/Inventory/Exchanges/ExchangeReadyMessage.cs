namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeReadyMessage : NetworkMessage
	{
		public const uint Id = 8926;
		public override uint MessageId => Id;
		public bool ready { get; set; }
		public ushort step { get; set; }

		public ExchangeReadyMessage(bool ready, ushort step)
		{
			this.ready = ready;
			this.step = step;
		}

		public ExchangeReadyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(ready);
			writer.WriteVarUShort(step);
		}

		public override void Deserialize(IDataReader reader)
		{
			ready = reader.ReadBoolean();
			step = reader.ReadVarUShort();
		}

	}
}
