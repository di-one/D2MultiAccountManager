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
	public class PaddockToSellListMessage : NetworkMessage
	{
		public const uint Id = 2097;
		public override uint MessageId => Id;
		public ushort pageIndex { get; set; }
		public ushort totalPage { get; set; }
		public IEnumerable<PaddockInformationsForSell> paddockList { get; set; }

		public PaddockToSellListMessage(ushort pageIndex, ushort totalPage, IEnumerable<PaddockInformationsForSell> paddockList)
		{
			this.pageIndex = pageIndex;
			this.totalPage = totalPage;
			this.paddockList = paddockList;
		}

		public PaddockToSellListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(pageIndex);
			writer.WriteVarUShort(totalPage);
			writer.WriteShort((short)paddockList.Count());
			foreach (var objectToSend in paddockList)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			pageIndex = reader.ReadVarUShort();
			totalPage = reader.ReadVarUShort();
			var paddockListCount = reader.ReadUShort();
			var paddockList_ = new PaddockInformationsForSell[paddockListCount];
			for (var paddockListIndex = 0; paddockListIndex < paddockListCount; paddockListIndex++)
			{
				var objectToAdd = new PaddockInformationsForSell();
				objectToAdd.Deserialize(reader);
				paddockList_[paddockListIndex] = objectToAdd;
			}
			paddockList = paddockList_;
		}

	}
}
