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
	public class ObjectItemInformationWithQuantity : ObjectItemMinimalInformation
	{
		public new const short Id = 3385;
		public override short TypeId => Id;
		public uint quantity { get; set; }

		public ObjectItemInformationWithQuantity(ushort objectGID, IEnumerable<ObjectEffect> effects, uint quantity)
		{
			this.objectGID = objectGID;
			this.effects = effects;
			this.quantity = quantity;
		}

		public ObjectItemInformationWithQuantity() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			quantity = reader.ReadVarUInt();
		}

	}
}
