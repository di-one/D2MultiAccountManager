namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ContactLookRequestByIdMessage : ContactLookRequestMessage
	{
		public new const uint Id = 1112;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }

		public ContactLookRequestByIdMessage(byte requestId, sbyte contactType, ulong playerId)
		{
			this.requestId = requestId;
			this.contactType = contactType;
			this.playerId = playerId;
		}

		public ContactLookRequestByIdMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(playerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerId = reader.ReadVarULong();
		}

	}
}
