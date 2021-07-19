namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractPartyMessage : NetworkMessage
	{
		public const uint Id = 2102;
		public override uint MessageId => Id;
		public uint partyId { get; set; }

		public AbstractPartyMessage(uint partyId)
		{
			this.partyId = partyId;
		}

		public AbstractPartyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(partyId);
		}

		public override void Deserialize(IDataReader reader)
		{
			partyId = reader.ReadVarUInt();
		}

	}
}
