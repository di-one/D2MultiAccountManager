namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeBidHousePriceMessage : NetworkMessage
	{
		public const uint Id = 6774;
		public override uint MessageId => Id;
		public ushort genId { get; set; }

		public ExchangeBidHousePriceMessage(ushort genId)
		{
			this.genId = genId;
		}

		public ExchangeBidHousePriceMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(genId);
		}

		public override void Deserialize(IDataReader reader)
		{
			genId = reader.ReadVarUShort();
		}

	}
}
