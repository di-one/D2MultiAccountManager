namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectAveragePricesMessage : NetworkMessage
	{
		public const uint Id = 6792;
		public override uint MessageId => Id;
		public IEnumerable<ushort> ids { get; set; }
		public IEnumerable<ulong> avgPrices { get; set; }

		public ObjectAveragePricesMessage(IEnumerable<ushort> ids, IEnumerable<ulong> avgPrices)
		{
			this.ids = ids;
			this.avgPrices = avgPrices;
		}

		public ObjectAveragePricesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)ids.Count());
			foreach (var objectToSend in ids)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)avgPrices.Count());
			foreach (var objectToSend in avgPrices)
            {
				writer.WriteVarULong(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var idsCount = reader.ReadUShort();
			var ids_ = new ushort[idsCount];
			for (var idsIndex = 0; idsIndex < idsCount; idsIndex++)
			{
				ids_[idsIndex] = reader.ReadVarUShort();
			}
			ids = ids_;
			var avgPricesCount = reader.ReadUShort();
			var avgPrices_ = new ulong[avgPricesCount];
			for (var avgPricesIndex = 0; avgPricesIndex < avgPricesCount; avgPricesIndex++)
			{
				avgPrices_[avgPricesIndex] = reader.ReadVarULong();
			}
			avgPrices = avgPrices_;
		}

	}
}
