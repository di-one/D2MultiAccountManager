namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HaapiValidationRequestMessage : NetworkMessage
	{
		public const uint Id = 9268;
		public override uint MessageId => Id;
		public string transaction { get; set; }

		public HaapiValidationRequestMessage(string transaction)
		{
			this.transaction = transaction;
		}

		public HaapiValidationRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(transaction);
		}

		public override void Deserialize(IDataReader reader)
		{
			transaction = reader.ReadUTF();
		}

	}
}
