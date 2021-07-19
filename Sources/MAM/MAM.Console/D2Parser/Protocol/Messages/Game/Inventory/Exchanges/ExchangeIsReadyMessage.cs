namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeIsReadyMessage : NetworkMessage
	{
		public const uint Id = 8864;
		public override uint MessageId => Id;
		public double objectId { get; set; }
		public bool ready { get; set; }

		public ExchangeIsReadyMessage(double objectId, bool ready)
		{
			this.objectId = objectId;
			this.ready = ready;
		}

		public ExchangeIsReadyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(objectId);
			writer.WriteBoolean(ready);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadDouble();
			ready = reader.ReadBoolean();
		}

	}
}
