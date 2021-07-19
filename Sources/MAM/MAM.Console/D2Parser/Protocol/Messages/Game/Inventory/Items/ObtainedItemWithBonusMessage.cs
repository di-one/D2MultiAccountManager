namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObtainedItemWithBonusMessage : ObtainedItemMessage
	{
		public new const uint Id = 9051;
		public override uint MessageId => Id;
		public uint bonusQuantity { get; set; }

		public ObtainedItemWithBonusMessage(ushort genericId, uint baseQuantity, uint bonusQuantity)
		{
			this.genericId = genericId;
			this.baseQuantity = baseQuantity;
			this.bonusQuantity = bonusQuantity;
		}

		public ObtainedItemWithBonusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(bonusQuantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			bonusQuantity = reader.ReadVarUInt();
		}

	}
}
