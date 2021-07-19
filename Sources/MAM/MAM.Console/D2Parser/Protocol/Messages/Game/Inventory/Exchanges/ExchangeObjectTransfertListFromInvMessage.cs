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
	public class ExchangeObjectTransfertListFromInvMessage : NetworkMessage
	{
		public const uint Id = 6814;
		public override uint MessageId => Id;
		public IEnumerable<uint> ids { get; set; }

		public ExchangeObjectTransfertListFromInvMessage(IEnumerable<uint> ids)
		{
			this.ids = ids;
		}

		public ExchangeObjectTransfertListFromInvMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)ids.Count());
			foreach (var objectToSend in ids)
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
		}

	}
}
