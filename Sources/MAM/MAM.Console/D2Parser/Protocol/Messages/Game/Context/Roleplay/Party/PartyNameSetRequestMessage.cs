namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyNameSetRequestMessage : AbstractPartyMessage
	{
		public new const uint Id = 2939;
		public override uint MessageId => Id;
		public string partyName { get; set; }

		public PartyNameSetRequestMessage(uint partyId, string partyName)
		{
			this.partyId = partyId;
			this.partyName = partyName;
		}

		public PartyNameSetRequestMessage() { }

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
