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
	public class HouseToSellListMessage : NetworkMessage
	{
		public const uint Id = 2920;
		public override uint MessageId => Id;
		public ushort pageIndex { get; set; }
		public ushort totalPage { get; set; }
		public IEnumerable<HouseInformationsForSell> houseList { get; set; }

		public HouseToSellListMessage(ushort pageIndex, ushort totalPage, IEnumerable<HouseInformationsForSell> houseList)
		{
			this.pageIndex = pageIndex;
			this.totalPage = totalPage;
			this.houseList = houseList;
		}

		public HouseToSellListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(pageIndex);
			writer.WriteVarUShort(totalPage);
			writer.WriteShort((short)houseList.Count());
			foreach (var objectToSend in houseList)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			pageIndex = reader.ReadVarUShort();
			totalPage = reader.ReadVarUShort();
			var houseListCount = reader.ReadUShort();
			var houseList_ = new HouseInformationsForSell[houseListCount];
			for (var houseListIndex = 0; houseListIndex < houseListCount; houseListIndex++)
			{
				var objectToAdd = new HouseInformationsForSell();
				objectToAdd.Deserialize(reader);
				houseList_[houseListIndex] = objectToAdd;
			}
			houseList = houseList_;
		}

	}
}
