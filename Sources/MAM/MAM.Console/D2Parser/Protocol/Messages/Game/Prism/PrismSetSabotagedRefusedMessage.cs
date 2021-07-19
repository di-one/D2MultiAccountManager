namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismSetSabotagedRefusedMessage : NetworkMessage
	{
		public const uint Id = 527;
		public override uint MessageId => Id;
		public ushort subAreaId { get; set; }
		public sbyte reason { get; set; }

		public PrismSetSabotagedRefusedMessage(ushort subAreaId, sbyte reason)
		{
			this.subAreaId = subAreaId;
			this.reason = reason;
		}

		public PrismSetSabotagedRefusedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteSByte(reason);
		}

		public override void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			reason = reader.ReadSByte();
		}

	}
}
