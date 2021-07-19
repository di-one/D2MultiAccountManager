namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseToSellListRequestMessage : NetworkMessage
	{
		public const uint Id = 6313;
		public override uint MessageId => Id;
		public ushort pageIndex { get; set; }

		public HouseToSellListRequestMessage(ushort pageIndex)
		{
			this.pageIndex = pageIndex;
		}

		public HouseToSellListRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(pageIndex);
		}

		public override void Deserialize(IDataReader reader)
		{
			pageIndex = reader.ReadVarUShort();
		}

	}
}
