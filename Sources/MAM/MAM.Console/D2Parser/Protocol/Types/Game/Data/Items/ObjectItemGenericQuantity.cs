namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectItemGenericQuantity : Item
	{
		public new const short Id = 5877;
		public override short TypeId => Id;
		public ushort objectGID { get; set; }
		public uint quantity { get; set; }

		public ObjectItemGenericQuantity(ushort objectGID, uint quantity)
		{
			this.objectGID = objectGID;
			this.quantity = quantity;
		}

		public ObjectItemGenericQuantity() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(objectGID);
			writer.WriteVarUInt(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectGID = reader.ReadVarUShort();
			quantity = reader.ReadVarUInt();
		}

	}
}
