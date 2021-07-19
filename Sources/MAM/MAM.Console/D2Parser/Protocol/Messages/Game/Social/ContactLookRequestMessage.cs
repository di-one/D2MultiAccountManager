namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ContactLookRequestMessage : NetworkMessage
	{
		public const uint Id = 8746;
		public override uint MessageId => Id;
		public byte requestId { get; set; }
		public sbyte contactType { get; set; }

		public ContactLookRequestMessage(byte requestId, sbyte contactType)
		{
			this.requestId = requestId;
			this.contactType = contactType;
		}

		public ContactLookRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteByte(requestId);
			writer.WriteSByte(contactType);
		}

		public override void Deserialize(IDataReader reader)
		{
			requestId = reader.ReadByte();
			contactType = reader.ReadSByte();
		}

	}
}
