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
	public class ExchangeObjectTransfertListWithQuantityToInvMessage : NetworkMessage
	{
		public const uint Id = 6881;
		public override uint MessageId => Id;
		public IEnumerable<uint> ids { get; set; }
		public IEnumerable<uint> qtys { get; set; }

		public ExchangeObjectTransfertListWithQuantityToInvMessage(IEnumerable<uint> ids, IEnumerable<uint> qtys)
		{
			this.ids = ids;
			this.qtys = qtys;
		}

		public ExchangeObjectTransfertListWithQuantityToInvMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)ids.Count());
			foreach (var objectToSend in ids)
            {
				writer.WriteVarUInt(objectToSend);
			}
			writer.WriteShort((short)qtys.Count());
			foreach (var objectToSend in qtys)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var idsCount = reader.ReadUShort();
			var ids_ = new uint[idsCount];
			for (var idsIndex = 0; idsIndex < idsCount; idsIndex++)
			{
				ids_[idsIndex] = reader.ReadVarUInt();
			}
			ids = ids_;
			var qtysCount = reader.ReadUShort();
			var qtys_ = new uint[qtysCount];
			for (var qtysIndex = 0; qtysIndex < qtysCount; qtysIndex++)
			{
				qtys_[qtysIndex] = reader.ReadVarUInt();
			}
			qtys = qtys_;
		}

	}
}
