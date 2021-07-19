namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockBuyableInformations
	{
		public const short Id  = 4586;
		public virtual short TypeId => Id;
		public ulong price { get; set; }
		public bool locked { get; set; }

		public PaddockBuyableInformations(ulong price, bool locked)
		{
			this.price = price;
			this.locked = locked;
		}

		public PaddockBuyableInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(price);
			writer.WriteBoolean(locked);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			price = reader.ReadVarULong();
			locked = reader.ReadBoolean();
		}

	}
}
