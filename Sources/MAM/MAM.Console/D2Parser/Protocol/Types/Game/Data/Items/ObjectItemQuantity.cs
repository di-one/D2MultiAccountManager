namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectItemQuantity : Item
	{
		public new const short Id = 5982;
		public override short TypeId => Id;
		public uint objectUID { get; set; }
		public uint quantity { get; set; }

		public ObjectItemQuantity(uint objectUID, uint quantity)
		{
			this.objectUID = objectUID;
			this.quantity = quantity;
		}

		public ObjectItemQuantity() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(objectUID);
			writer.WriteVarUInt(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectUID = reader.ReadVarUInt();
			quantity = reader.ReadVarUInt();
		}

	}
}
