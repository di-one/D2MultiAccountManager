namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HaapiCancelBidRequestMessage : NetworkMessage
	{
		public const uint Id = 8162;
		public override uint MessageId => Id;
		public ulong objectId { get; set; }
		public sbyte type { get; set; }

		public HaapiCancelBidRequestMessage(ulong objectId, sbyte type)
		{
			this.objectId = objectId;
			this.type = type;
		}

		public HaapiCancelBidRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(objectId);
			writer.WriteSByte(type);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarULong();
			type = reader.ReadSByte();
		}

	}
}
