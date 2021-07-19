namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class DocumentReadingBeginMessage : NetworkMessage
	{
		public const uint Id = 7475;
		public override uint MessageId => Id;
		public ushort documentId { get; set; }

		public DocumentReadingBeginMessage(ushort documentId)
		{
			this.documentId = documentId;
		}

		public DocumentReadingBeginMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(documentId);
		}

		public override void Deserialize(IDataReader reader)
		{
			documentId = reader.ReadVarUShort();
		}

	}
}
