namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ContactLookErrorMessage : NetworkMessage
	{
		public const uint Id = 3569;
		public override uint MessageId => Id;
		public uint requestId { get; set; }

		public ContactLookErrorMessage(uint requestId)
		{
			this.requestId = requestId;
		}

		public ContactLookErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(requestId);
		}

		public override void Deserialize(IDataReader reader)
		{
			requestId = reader.ReadVarUInt();
		}

	}
}
