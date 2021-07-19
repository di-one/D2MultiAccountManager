namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdolPartyLostMessage : NetworkMessage
	{
		public const uint Id = 5868;
		public override uint MessageId => Id;
		public ushort idolId { get; set; }

		public IdolPartyLostMessage(ushort idolId)
		{
			this.idolId = idolId;
		}

		public IdolPartyLostMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(idolId);
		}

		public override void Deserialize(IDataReader reader)
		{
			idolId = reader.ReadVarUShort();
		}

	}
}
