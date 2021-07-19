namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyNameUpdateMessage : AbstractPartyMessage
	{
		public new const uint Id = 717;
		public override uint MessageId => Id;
		public string partyName { get; set; }

		public PartyNameUpdateMessage(uint partyId, string partyName)
		{
			this.partyId = partyId;
			this.partyName = partyName;
		}

		public PartyNameUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(partyName);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			partyName = reader.ReadUTF();
		}

	}
}
