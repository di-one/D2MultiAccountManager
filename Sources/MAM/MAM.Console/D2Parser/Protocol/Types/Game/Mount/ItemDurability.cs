namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ItemDurability
	{
		public const short Id  = 988;
		public virtual short TypeId => Id;
		public short durability { get; set; }
		public short durabilityMax { get; set; }

		public ItemDurability(short durability, short durabilityMax)
		{
			this.durability = durability;
			this.durabilityMax = durabilityMax;
		}

		public ItemDurability() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort(durability);
			writer.WriteShort(durabilityMax);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			durability = reader.ReadShort();
			durabilityMax = reader.ReadShort();
		}

	}
}
