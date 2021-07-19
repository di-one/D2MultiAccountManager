namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ContactLookRequestByNameMessage : ContactLookRequestMessage
	{
		public new const uint Id = 2664;
		public override uint MessageId => Id;
		public string playerName { get; set; }

		public ContactLookRequestByNameMessage(byte requestId, sbyte contactType, string playerName)
		{
			this.requestId = requestId;
			this.contactType = contactType;
			this.playerName = playerName;
		}

		public ContactLookRequestByNameMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(playerName);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerName = reader.ReadUTF();
		}

	}
}
