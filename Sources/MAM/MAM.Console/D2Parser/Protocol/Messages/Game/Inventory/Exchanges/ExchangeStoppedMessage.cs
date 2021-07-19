namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStoppedMessage : NetworkMessage
	{
		public const uint Id = 4494;
		public override uint MessageId => Id;
		public ulong objectId { get; set; }

		public ExchangeStoppedMessage(ulong objectId)
		{
			this.objectId = objectId;
		}

		public ExchangeStoppedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(objectId);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarULong();
		}

	}
}
