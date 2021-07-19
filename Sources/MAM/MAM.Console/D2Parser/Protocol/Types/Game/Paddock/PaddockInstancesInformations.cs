namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockInstancesInformations : PaddockInformations
	{
		public new const short Id = 5330;
		public override short TypeId => Id;
		public IEnumerable<PaddockBuyableInformations> paddocks { get; set; }

		public PaddockInstancesInformations(ushort maxOutdoorMount, ushort maxItems, IEnumerable<PaddockBuyableInformations> paddocks)
		{
			this.maxOutdoorMount = maxOutdoorMount;
			this.maxItems = maxItems;
			this.paddocks = paddocks;
		}

		public PaddockInstancesInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)paddocks.Count());
			foreach (var objectToSend in paddocks)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var paddocksCount = reader.ReadUShort();
			var paddocks_ = new PaddockBuyableInformations[paddocksCount];
			for (var paddocksIndex = 0; paddocksIndex < paddocksCount; paddocksIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<PaddockBuyableInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				paddocks_[paddocksIndex] = objectToAdd;
			}
			paddocks = paddocks_;
		}

	}
}
