namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockItem : ObjectItemInRolePlay
	{
		public new const short Id = 8895;
		public override short TypeId => Id;
		public ItemDurability durability { get; set; }

		public PaddockItem(ushort cellId, ushort objectGID, ItemDurability durability)
		{
			this.cellId = cellId;
			this.objectGID = objectGID;
			this.durability = durability;
		}

		public PaddockItem() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			durability.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			durability = new ItemDurability();
			durability.Deserialize(reader);
		}

	}
}
