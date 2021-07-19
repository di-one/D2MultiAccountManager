namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObtainedItemMessage : NetworkMessage
	{
		public const uint Id = 6736;
		public override uint MessageId => Id;
		public ushort genericId { get; set; }
		public uint baseQuantity { get; set; }

		public ObtainedItemMessage(ushort genericId, uint baseQuantity)
		{
			this.genericId = genericId;
			this.baseQuantity = baseQuantity;
		}

		public ObtainedItemMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(genericId);
			writer.WriteVarUInt(baseQuantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			genericId = reader.ReadVarUShort();
			baseQuantity = reader.ReadVarUInt();
		}

	}
}
