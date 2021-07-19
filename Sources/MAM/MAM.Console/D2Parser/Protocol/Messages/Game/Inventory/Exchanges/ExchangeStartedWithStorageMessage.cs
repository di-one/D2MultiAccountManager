namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeStartedWithStorageMessage : ExchangeStartedMessage
	{
		public new const uint Id = 8749;
		public override uint MessageId => Id;
		public uint storageMaxSlot { get; set; }

		public ExchangeStartedWithStorageMessage(sbyte exchangeType, uint storageMaxSlot)
		{
			this.exchangeType = exchangeType;
			this.storageMaxSlot = storageMaxSlot;
		}

		public ExchangeStartedWithStorageMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(storageMaxSlot);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			storageMaxSlot = reader.ReadVarUInt();
		}

	}
}
