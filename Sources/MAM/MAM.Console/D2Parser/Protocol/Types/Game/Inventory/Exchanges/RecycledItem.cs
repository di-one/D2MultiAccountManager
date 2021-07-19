namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class RecycledItem
	{
		public const short Id  = 4098;
		public virtual short TypeId => Id;
		public ushort objectId { get; set; }
		public uint qty { get; set; }

		public RecycledItem(ushort objectId, uint qty)
		{
			this.objectId = objectId;
			this.qty = qty;
		}

		public RecycledItem() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objectId);
			writer.WriteUInt(qty);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUShort();
			qty = reader.ReadUInt();
		}

	}
}
