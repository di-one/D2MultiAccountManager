namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ForgettableSpellEquipmentSlotsMessage : NetworkMessage
	{
		public const uint Id = 3440;
		public override uint MessageId => Id;
		public short quantity { get; set; }

		public ForgettableSpellEquipmentSlotsMessage(short quantity)
		{
			this.quantity = quantity;
		}

		public ForgettableSpellEquipmentSlotsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarShort(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			quantity = reader.ReadVarShort();
		}

	}
}
